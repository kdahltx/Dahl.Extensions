using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;

namespace Dahl.Extensions
{
    public static class PropertyExt
    {
        private static ConcurrentDictionary<PropertyInfo,IPropertyAccessor> _cache = new ConcurrentDictionary<PropertyInfo,IPropertyAccessor>();

        ///--------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IPropertyAccessor[] GetAccessorList( this Type type )
        {
            var obj = Activator.CreateInstance( type );
            IPropertyAccessor[] accessors = obj.GetType()
                                               .GetProperties()
                                               .Select( ( pi, i ) => pi.GetAccessor( i ) )
                                               .ToArray();
            return accessors;
        }

        ///--------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static IPropertyAccessor GetAccessor( this PropertyInfo propertyInfo, int ordinal )
        {
            IPropertyAccessor result = null;
            if ( !_cache.TryGetValue( propertyInfo, out result ) )
            {
                result = CreateAccessor( propertyInfo, ordinal );
                _cache.TryAdd( propertyInfo, result ); ;
            }

            return result;
        }

        ///--------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static IPropertyAccessor CreateAccessor( this PropertyInfo pi, int ordinal )
        {
            var GenType = typeof( PropertyAccessor<> ).MakeGenericType( pi.DeclaringType );
            return (IPropertyAccessor)Activator.CreateInstance( GenType, new object[]{ pi, ordinal } );
        }

        ///--------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public class PropertyAccessor<TEntity> : IPropertyAccessor where TEntity : class
        {
            public PropertyAccessor( PropertyInfo pi, int ordinal )
            {
                PropertyInfo = pi;
                Name = pi.Name;
                Ordinal = ordinal;
                Get = pi.CreateGetterDelegate<TEntity>();
                Set = pi.CreateSetterDelegate<TEntity>();
            }

            public PropertyInfo PropertyInfo { get; set; }
            public string Name { get; set; }
            public int Ordinal { get; set; }

            public object GetValue( object source )
            {
                return Get( source as TEntity );
            }

            public void SetValue( object source, object value )
            {
                Set( source as TEntity, value );
            }

            private Func<TEntity, object> Get;
            private Action<TEntity, object> Set;
        }

        //---------------------------------------------------------------------------------------------
        /// <summary>
        /// As far as property accessors go, this usage produces the best results, barely better than
        /// creating a regular delegate.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="pi"></param>
        /// <returns></returns>
        public static Func<TEntity, object> CreateGetterDelegate<TEntity>( this PropertyInfo pi )
        {
            ParameterExpression instance  = Expression.Parameter( typeof( TEntity ), "instance" );   // Define parameter that is passed - will be current object
            MemberExpression    getBody   = Expression.Property( instance, pi );                     // Define expression to get value from property
            UnaryExpression     castAsGet = Expression.TypeAs( getBody, typeof( object ) );          // Make sure result of get method is cast as an object
             
            // Create lambda expression for property access and compile
            Expression<Func<TEntity, object>> lamda = Expression.Lambda<Func<TEntity, object>>( castAsGet, instance );
            return lamda.Compile();
        }

        //---------------------------------------------------------------------------------------------
        // Credit for this one goes to person at this link. 
        // https://weblogs.asp.net/marianor/using-expression-trees-to-get-property-getter-and-setters
        //
        // It could have saved me a lot of time if I'd just found this one to start with. Turns out 
        // I was missing the Expression.Convert(,) in the Expression.Call() statement.
        //
        public static Action<TEntity, object> CreateSetterDelegate<TEntity>( this PropertyInfo pi )
        {
            ParameterExpression  instance = Expression.Parameter( pi.DeclaringType, "instance" );  // Define parameter that is passed - will be current object
            ParameterExpression  arg      = Expression.Parameter( typeof( object ), "param" );
            MethodCallExpression setBody  = Expression.Call( instance, 
                                                             pi.GetSetMethod(),
                                                             Expression.Convert(arg, pi.PropertyType ) );    // Define expression to set value from property

            // Create lambda expression for property access and compile
            var lamda = Expression.Lambda( setBody, instance, arg );
            return (Action<TEntity,object>)lamda.Compile();
        }

    }

    public interface IPropertyAccessor
    {
        PropertyInfo PropertyInfo { get; }
        string Name { get; }
        int Ordinal { get; set; }
        object GetValue( object source );
        void SetValue( object source, object value );
    }
}
