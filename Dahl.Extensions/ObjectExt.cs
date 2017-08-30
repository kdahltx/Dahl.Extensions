using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
        /// <param name="S"></param>
        /// <returns></returns>
        public static T GetCopy<T>( this T S )
        {
            T newObj = Activator.CreateInstance<T>();
            foreach ( PropertyInfo i in newObj.GetType().GetProperties() )
            {
                //"EntitySet" is specific to link and this conditional logic is optional/can be ignored
                if ( i.CanWrite && i.PropertyType.Name.Contains( "EntitySet" ) == false )
                {
                    PropertyInfo propertyInfo = S.GetType().GetProperty( i.Name );
                    if ( propertyInfo != null )
                    {
                        object value = propertyInfo.GetValue( S, null );
                        i.SetValue( newObj, value, null );
                    }
                }
            }

            return newObj;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Perform a deep Copy of an object, object must be serializable.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="src">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>( this T src )
        {
            if ( !typeof( T ).IsSerializable )
            {
                throw new ArgumentException( "The type must be serializable.", nameof( src ) );
            }

            // Don't serialize a null object, simply return the default for that object
            if ( object.ReferenceEquals( src, null ) )
            {
                return default( T );
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using ( stream )
            {
                formatter.Serialize( stream, src );
                stream.Seek( 0, SeekOrigin.Begin );
                return (T)formatter.Deserialize( stream );
            }
        }
    }
}
