using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Dahl.Extensions
{
    public static class StringExt
    {
        public static CultureInfo CultureInfo { get; set; } = CultureInfo.InvariantCulture;
        public static StringComparison IgnoreCase { get; set; } = StringComparison.OrdinalIgnoreCase;

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Removes whitespace from beginning and end of string, this can handle null strings.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string TrimWhiteSpace( this string src )
        {
            if ( string.IsNullOrEmpty( src ) )
                return string.Empty;

            return src.Trim();
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string to an integer
        /// </summary>
        /// <param name="src"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static byte ToByte( this object src, byte def = default )
        {
            byte target = def;
            if ( src is string )
            {
                if ( Byte.TryParse( src.ToString(), out byte result ) )
                    target = result;
            }
            else if ( src is byte )
                target = (byte)src;

            return target;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string to an integer
        /// </summary>
        /// <param name="src"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static int ToInt32( this object src, int def = default )
        {
            int target = def;
            if ( src is string )
                target = IntParse( src.ToString() );
            else if ( src is int )
                target = (int)src;

            return target;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Convert a string to an integer
        /// </summary>
        /// <param name="src">The string to parse</param>
        /// <param name="def">If provided, a value to return if the string cannot be parsed, if not
        ///                   provided zero will be used as the default value</param>
        /// <returns>The parsed value if string represents a legal integer, otherwise the default value</returns>
        public static int IntParse( this string src, int def = default )
        {
            return int.TryParse( src, out var target ) ? target : def;
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether 2 specified T:String objects have the same value ignoring case,
        /// uses StringComparison.OrdinalIgnoreCase
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="val">the value to compare</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase( this string src, string val )
        {
            if ( string.IsNullOrEmpty( src ) )
            {
                if ( string.IsNullOrEmpty( val ) )
                    return true;
            }

            if ( string.IsNullOrEmpty( val ) )
                return false;

            return string.Equals( src, val, IgnoreCase );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether 2 specified T:String objects have the same value ignoring case,
        /// uses StringComparison.OrdinalIgnoreCase
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="val">the value to compare</param>
        /// <returns></returns>
        public static bool NotEqual( this string src, string val )
        {
            if ( string.IsNullOrEmpty( src ) )
            {
                if ( string.IsNullOrEmpty( val ) )
                    return false;
            }

            if ( string.IsNullOrEmpty( val ) )
                return true;

            return !string.Equals( src, val );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether 2 specified T:String objects have the same value ignoring case,
        /// uses StringComparison.OrdinalIgnoreCase
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="val">the value to compare</param>
        /// <returns></returns>
        public static bool NotEqualIgnoreCase( this string src, string val )
        {
            if ( string.IsNullOrEmpty( src ) )
            {
                if ( string.IsNullOrEmpty( val ) )
                    return false;
            }

            if ( string.IsNullOrEmpty( val ) )
                return true;

            return !string.Equals( src, val, IgnoreCase );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Returns a value indicating whether the specified String object occurs within this string ignoring case,
        /// uses StringComparison.OrdinalIgnoreCase
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="val">the value to finde</param>
        /// <returns></returns>
        public static bool ContainsIgnoreCase( this string src, string val )
        {
            if ( string.IsNullOrEmpty( src ) || string.IsNullOrEmpty( val ) )
                return false;

            return src.IndexOf( val, IgnoreCase ) >= 0;
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Returns a value indicating whether the specified String object contains anything
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty( this string src )
        {
            return string.IsNullOrEmpty( src );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Returns a value indicating whether the specified String object contains anything
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty( this string src )
        {
            return !string.IsNullOrEmpty( src );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string ignoring case,
        /// uses StringComparison.OrdinalIgnoreCase
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="val">the value to finde</param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase( this string src, string val )
        {
            if ( string.IsNullOrEmpty( src ) || string.IsNullOrEmpty( val ) )
                return false;

            return src.StartsWith( val, IgnoreCase );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether the end of this string instance matches the specified string ignoring case,
        /// uses StringComparison.OrdinalIgnoreCase
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="val">the value to finde</param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase( this string src, string val )
        {
            if ( string.IsNullOrEmpty( src ) || string.IsNullOrEmpty( val ) )
                return false;

            return src.EndsWith( val, IgnoreCase );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Replaces the oldValue with the specfied new value ignoring case.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="oldValue">The part of the string to be replaced by the newValue</param>
        /// <param name="newValue">The new string to replace the oldValue</param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase( this string src, string oldValue, string newValue )
        {
            try
            {
                return Regex.Replace( src, oldValue, newValue, RegexOptions.IgnoreCase );
            }
            catch
            {
                return oldValue;
            }
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Uses InvariantCulture
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ToString( this string src )
        {
            return src.ToString( CultureInfo );
        }

        ///-----------------------------------------------------------------------------------------
        /// <summary>
        /// Takes a string and if its length is greater than maxLen it trims it to maxLen-3 and
        /// appends three periods to the string. if maxLen is less than or equal to 3 then
        /// the string returned is 3 periods.
        /// </summary>
        /// <param name="src">the string to compare</param>
        /// <param name="maxLen">maximun length of string to return</param>
        /// <returns></returns>
        public static string ToEllipsis( this string src, int maxLen )
        {
            if ( string.IsNullOrEmpty( src ) )
                return string.Empty;

            maxLen -= 3;
            if ( maxLen < 0 )
                maxLen = 0;

            if ( src.Length > maxLen )
                return $"{src.Substring( 0, maxLen )}...";

            return src.TrimEnd();
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Returns a string up to the maxLen specified.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="maxLen">The maximum length of the sting</param>
        /// <returns></returns>
        public static string ToString( this string src, int maxLen )
        {
            if ( string.IsNullOrEmpty( src ) )
                return string.Empty;

            if ( src.Length > maxLen )
                return src.Substring( 0, maxLen );

            return src.TrimEnd();
        }

        /// ----------------------------------------------------------------------------------------
        ///  <summary>
        ///  If possbile makes a Guid from the string provided, otherwide it returns an Empty Guid.
        ///  </summary>
        ///  <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid ToGuid( this string src, Guid defaultValue = default )
        {
            try
            {
                return src.IsNotNullOrEmpty() ? new Guid( src ) : defaultValue;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string to a DateTime object. If the string is null or empty the
        /// object will be initialize with the supplied defaultValue.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime( this string src, DateTime defaultValue = default )
        {
            return ToDate( src, defaultValue );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Creates a new DateTime object
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDate( this string src, DateTime defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            DateTime result;
            if ( !DateTime.TryParse( src, out result ) )
                result = defaultValue;

            return new DateTime( result.Year, result.Month, result.Day );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Returns true if string is a valid date
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsDate( this string src )
        {
            return DateTime.TryParse( src, out _ );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string into a boolean value.
        /// </summary>
        /// <param name="src">Valid values are "f" or "false" and "t" or "true"</param>
        /// <param name="defaultValue">If parameter is not specified, false is returned.</param>
        /// <returns></returns>
        public static bool ToBool( this string src, bool defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            string s = src.ToLower().Trim();
            if ( s.Equals( "false" ) || s.Equals( "f" ) || s == "0" )
                return false;

            return s.Equals( "true" ) || s.Equals( "t" ) || s == "1";
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string to a short or Int16 value.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static short ToInt16( this string src, short defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;
            src = src.Replace( ",", "" );
            if ( short.TryParse( src, out var result ) )
                return result;

            return defaultValue;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string to an int or Int32 value.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32( this string src, int defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            int result;
            src = src.Replace( ",", "" );
            if ( int.TryParse( src, out result ) )
                return result;

            return defaultValue;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts string to an Int64 value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64 ToInt64( this string src, Int64 defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            Int64 result;
            src = src.Replace( ",", "" );
            if ( Int64.TryParse( src, out result ) )
                return result;

            return defaultValue;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts a string to a Double value. Removes commas if present.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double ToDouble( this string src, double defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            double result;
            src = src.Replace( ",", "" );
            if ( double.TryParse( src, out result ) )
                return result;

            return defaultValue;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts a string to a Float, removes commas if present
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ToFloat( this string src, float defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            float result;
            src = src.Replace( ",", "" );
            if ( float.TryParse( src, out result ) )
                return result;

            return defaultValue;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts a string to a decimal removing commas if present
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal( this string src, decimal defaultValue = default )
        {
            if ( string.IsNullOrEmpty( src ) )
                return defaultValue;

            src = src.Replace( ",", "" );
            if ( decimal.TryParse( src, out var result ) )
                return result;

            return defaultValue;
        }

        //-----------------------------------------------------------------------------------------
        private static readonly Regex _digitsPattern = new Regex("^[0-9]*$");
        private static readonly Regex _ssnPattern    = new Regex(@"^(?!000)(?!666)(?!9[0-9][0-9])\d{3}[- ]?(?!00)\d{2}[- ]?(?!0000)\d{4}$");
        private static readonly Regex _emailPattern  = new Regex( @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$" );
        /// ----------------------------------------------------------------------------------------
        ///  <summary>
        ///  Determines if the string is a valid SSN format and valid SSN.
        ///  </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsSsn( this string src )
        {
            if ( string.IsNullOrEmpty( src ) )
                return false;

            return _ssnPattern.Match( src ).Success;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsDigitsOnly( this string src )
        {
            return _digitsPattern.Match( src ).Success;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Only Digits
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string OnlyDigits( this string src )
        {
            return _digitsPattern.Replace( src, string.Empty );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts a DateTime object to a string
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ToShortDateString( this DateTime? src)
        {
            return src?.ToShortDateString() ?? string.Empty;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts a DateTime object to a string
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ToLongDateString( this DateTime? src )
        {
            return src?.ToLongDateString() ?? string.Empty;
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Test string against the email pattern for a valid format.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsValidEmailFormat( this string src )
        {
            if ( src.IsNullOrEmpty() )
                return false;

            return _emailPattern.Match( src ).Success;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Formats a string array into a single string appending each string with an html line
        /// break tag <br />.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string FormatWithLineBreaks( this string[] src )
        {
            var sb = new StringBuilder();
            foreach ( string s in src )
            {
                sb.Append( s + "<br />" );
            }

            return sb.ToString();
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Formats a string as either a 7 or 10 digit phone src. (Does not strip out non-numeric data)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string AsPhoneNumber( this string src )
        {
            if ( string.IsNullOrWhiteSpace( src ) )
                return src;

            string formatedNumber = src;
            switch ( src.Length )
            {
                case 7 :
                    formatedNumber = $"{src.Substring( 0, 3 )}-{src.Substring( 3, 4 )}";
                    break;

                case 10 :
                    formatedNumber = $"({src.Substring( 0, 3 )}) {src.Substring( 3, 3 )}-{src.Substring( 6, 4 )}";
                    break;
            }
            return formatedNumber;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Formats a 9 character string as xxx-xx-xxxx
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string AsSsn( this string src )
        {
            if ( string.IsNullOrWhiteSpace( src ) )
                return string.Empty;

            if ( src.Length != 9 )
                return src;

            return $"{src.Substring( 0, 3 )}-{src.Substring( 3, 2 )}-{src.Substring( 5, 4 )}";
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Removes the line from the object, lineNumber is 0 based and lines are split on
        /// Environment.NewLine character.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="lineNumber">line src to be removed from StringBuilder object</param>
        /// <returns></returns>
        public static string RemoveLine( this string src, int lineNumber )
        {
            string[] lines = src.Split( new[] { Environment.NewLine }, StringSplitOptions.None );
            lines[lineNumber] = string.Empty;
            return string.Join( Environment.NewLine, lines );
        }
    }
}
