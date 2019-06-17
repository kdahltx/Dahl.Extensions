using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Dahl.Extensions
{
    public static class LinqExt
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Sorts the elements of a sequence according to a key. 
        /// </summary>
        /// <typeparam name="Tsrc"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<Tsrc> OrderBy<Tsrc, TKey>( this IEnumerable<Tsrc> src,
                                                                    Func<Tsrc, TKey> keySelector,
                                                                    bool descending )
        {
            return descending ? src.OrderByDescending( keySelector ) : src.OrderBy( keySelector );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tsrc"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public static IOrderedQueryable<Tsrc> OrderBy<Tsrc, TKey>( this IQueryable<Tsrc> src,
                                                                   Expression<Func<Tsrc, TKey>> keySelector,
                                                                   bool descending )
        {
            return descending ? src.OrderByDescending( keySelector ) : src.OrderBy( keySelector );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortAscending"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderBy<T>( this IQueryable<T> src,
                                                string sortExpression,
                                                bool sortAscending = true )
        {
            return sortAscending
                       ? src.OrderBy( f => OrderFunc( f, sortExpression ) )
                       : src.OrderByDescending( f => OrderFunc( f, sortExpression ) );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="sortExpression"></param>
        /// <param name="sortAscending"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderBy<T>( this IEnumerable<T> src,
                                                 string sortExpression,
                                                 bool sortAscending = true )
        {
            return sortAscending
                       ? src.OrderBy( f => OrderFunc( f, sortExpression ) )
                       : src.OrderByDescending( f => OrderFunc( f, sortExpression ) );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetChildObject<T>( T src, string propertyName )
        {
            Type t = src.GetType();
            PropertyInfo prop = t.GetProperty( propertyName );
            if ( prop == null )
            {
                string msg = $"PropertyName \"{propertyName}\" is not defined in class \"{src.GetType().FullName}\".";
                throw new ArgumentException( msg );
            }

            return prop.GetValue( src, null ) ?? Activator.CreateInstance( prop.PropertyType );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static object OrderFunc<T>( T src, string propertyName )
        {
            string propName = propertyName;
            object newObj = src;

            if ( propertyName.Contains( '.' ) )
            {
                // the requested property is contained in a child object
                string[] parts = propertyName.Split( '.' );
                int numParts = parts.Length - 1;
                for ( int i = 0; i < numParts; i++ )
                    newObj = GetChildObject( newObj, parts[i] );

                propName = parts[numParts];
            }

            PropertyInfo propertyGetter = newObj.GetType()
                                                .GetProperty( propName,
                                                              BindingFlags.Public |
                                                              BindingFlags.Instance |
                                                              BindingFlags.IgnoreCase );
            if ( propertyGetter == null )
            {
                string msg = $"Sort Expression could not find the provided property name: {propertyName}.";
                throw new ArgumentException( msg );
            }

            return propertyGetter.GetValue( newObj, null );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSrc"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="src"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TSrc> DistinctBy<TSrc, TKey>( this IEnumerable<TSrc> src, Func<TSrc, TKey> selector )
        {
            HashSet<TKey> keys = new HashSet<TKey>();
            return src.Where( element => keys.Add( selector( element ) ) );
        }
    }
}
