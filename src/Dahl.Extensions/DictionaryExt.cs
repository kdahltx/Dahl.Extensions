using System.Collections;
using System.Collections.Specialized;

namespace Dahl.Extensions
{
    public static class DictionaryExt
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValue<T>( this IDictionary src, string key, T defaultValue )
        {
            object value = src[key] ?? defaultValue;
            return (T)value;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GetValue( this NameValueCollection src, string Key )
        {
            return string.IsNullOrEmpty( src[Key] ) ? string.Empty : src.Get( Key );
        }
    }
}
