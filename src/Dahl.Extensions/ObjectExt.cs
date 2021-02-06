using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Dahl.Extensions
{
    public static class ObjectExt
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Takes an object and returns it as a string.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string AsString( this object src )
        {
            return src as string;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to DateTime
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static DateTime AsDateTime( this object src )
        {
            return (DateTime)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to short
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static short AsShort( this object src )
        {
            return (short)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to int
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int AsInt( this object src )
        {
            return (int)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to long
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static long AsLong( this object src )
        {
            return (long)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to bool
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool AsBool( this object src )
        {
            return (bool)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to byte
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte AsByte( this object src )
        {
            return (byte)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to DateTime?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static DateTime? AsNullableDateTime( this object src )
        {
            return src as DateTime?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to short?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static short? AsNullableShort( this object src )
        {
            return src as short?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to int?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int? AsNullableInt( this object src )
        {
            return src as int?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to long?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static long? AsNullableLong( this object src )
        {
            return src as long?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to bool?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool? AsNullableBool( this object src )
        {
            return src as bool?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to byte?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte? AsNullableByte( this object src )
        {
            return (byte?)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Casts object to DateTime?
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static DateTime? AsDateTimeNullable( this object src )
        {
            return src as DateTime?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static short? AsShortNullable( this object src )
        {
            return src as short?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int? AsIntNullable( this object src )
        {
            return src as int?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static long? AsLongNullable( this object src )
        {
            return src as long?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool? AsBoolNullable( this object src )
        {
            return src as bool?;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte? AsByteNullable( this object src )
        {
            return (byte?)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte AsTinyInt( this object src )
        {
            return (byte)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte? AsTinyIntNullable( this object src )
        {
            return (byte?)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static short AsSmallInt( this object src )
        {
            return (short)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static short? AsSmallIntNullable( this object src )
        {
            return (short?)src;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Copy properties from src object into destination object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">copy data from this object into the specified dst object</param>
        /// <param name="dst">copy data into this object</param>
        public static void CopyFrom<T>( this T dst, T src )
        {
            PropertyInfo[] srcProperties = src.GetType().GetProperties( BindingFlags.Public | BindingFlags.Instance );
            foreach ( PropertyInfo srcProperty in srcProperties )
            {
                if ( srcProperty.CanRead && srcProperty.CanWrite )
                {
                    PropertyInfo dstProperty = dst.GetType().GetProperty( srcProperty.Name );
                    if ( dstProperty != null )
                    {
                        object val = srcProperty.GetValue( src, null );
                        dstProperty.SetValue( dst, val, null );
                    }
                }
            }
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Makes a new object and copies 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static T GetCopy<T>( this T src )
        {
            T newObj = Activator.CreateInstance<T>();
            foreach ( PropertyInfo i in newObj.GetType().GetProperties() )
            {
                //"EntitySet" is specific to link and this conditional logic is optional/can be ignored
                if ( i.CanWrite && i.PropertyType.Name.Contains( "EntitySet" ) == false )
                {
                    PropertyInfo propertyInfo = src.GetType().GetProperty( i.Name );
                    if ( propertyInfo != null )
                    {
                        object value = propertyInfo.GetValue( src, null );
                        i.SetValue( newObj, value, null );
                    }
                }
            }

            return newObj;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Perform a deep Copy of an object.
        /// 
        /// If an object is not serializable it uses Newtonsoft to serialize object
        /// to a json string then deserializes the string back to a new object. The
        /// serialization method uses settings to preserve object references.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="src">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>( this T src )
        {
            if ( !typeof( T ).IsSerializable )
            {
                var jsonSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                };

                var json = JsonConvert.SerializeObject( src, jsonSettings );
                T obj = JsonConvert.DeserializeObject<T>( json );

                return obj;
            }

            // Don't serialize a null object, simply return the default for that object
            if ( src == null )
                return default;

            var jsonString = SerializeToJson<T>( src );
            if ( jsonString.IsNullOrEmpty() )
                return default;

            return DeserializeFromJson<T>( jsonString );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Uses Newtonsoft.Json because it's widely used and System.Text.Json only supports
        /// .NET Core 3.0 and up.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string SerializeToJson<T>( this T src, Newtonsoft.Json.Formatting formatting = Formatting.None )
        {
            if ( src == null )
                return string.Empty;

            var settings = new JsonSerializerSettings {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = (formatting == Formatting.None ? Formatting.None : Formatting.Indented)
            };

            return JsonConvert.SerializeObject( src, settings );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Uses Newtonsoft.Json because it's widely used and System.Text.Json only supports
        /// .NET Core 3.0 and up.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static T DeserializeFromJson<T>( this string src )
        {
            return JsonConvert.DeserializeObject<T>( src );
        }
    }
}
