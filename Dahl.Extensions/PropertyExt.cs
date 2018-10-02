using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Dahl.Extensions
{
    public static class PropertyExt
    {
        private static readonly ConcurrentDictionary<PropertyInfo,IPropertyAccessor> _cache = new ConcurrentDictionary<PropertyInfo,IPropertyAccessor>();

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
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public static IPropertyAccessor GetAccessor( this PropertyInfo propertyInfo, int ordinal )
        {
            if ( _cache.TryGetValue( propertyInfo, out var result ) )
                return result;

            var genType = typeof( PropertyAccessor<,> ).MakeGenericType( propertyInfo.ReflectedType, propertyInfo.PropertyType );
            result = (IPropertyAccessor) Activator.CreateInstance( genType, new object[] { propertyInfo, ordinal } );

            _cache.TryAdd( propertyInfo, result );
            return result;
        }

        ///--------------------------------------------------------------------------------------------
        /// <summary>
        /// Changed delete creation and usage because the other didn't work with getting properties in
        /// base classes.
        /// 
        /// Reference: https://stackoverflow.com/questions/724143/how-do-i-create-a-delegate-for-a-net-property
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        private sealed class PropertyAccessor<TEntity,TValue> : IPropertyAccessor where TEntity : class
        {
            public PropertyAccessor( PropertyInfo pi, int ordinal )
            {
                PropertyInfo = pi;
                Name         = pi.Name;
                Ordinal      = ordinal;

                var getterInfo = pi.GetGetMethod( true );
                var setterInfo = pi.GetSetMethod( true );

                _getter = (Func<TEntity,TValue>)Delegate.CreateDelegate( typeof( Func<TEntity,TValue> ),     getterInfo );
                _setter = (Action<TEntity,TValue>)Delegate.CreateDelegate( typeof( Action<TEntity,TValue> ), setterInfo );
            }

            public PropertyInfo PropertyInfo { get; }
            public string       Name         { get; }
            public int          Ordinal      { get; set; }

            public object GetValue( object source )             { return _getter( source as TEntity ); }
            public void SetValue( object source, object value ) { _setter( source as TEntity, (TValue)value ); }

            private readonly Func<TEntity,TValue>   _getter;
            private readonly Action<TEntity,TValue> _setter;
        }
    }

    public interface IPropertyAccessor
    {
        string       Name         { get; }
        int          Ordinal      { get; set; }
        PropertyInfo PropertyInfo { get; }

        object GetValue( object source );
        void   SetValue( object source, object value );
    }
}
