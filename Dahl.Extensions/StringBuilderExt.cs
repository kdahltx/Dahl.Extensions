using System;
using System.Text;

namespace Dahl.Extensions
{
    public static class StringBuilderExt
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format )
        {
            StringBuilder sb = src.AppendFormat( format );
            sb.AppendLine();
            return sb;
        }

        /// ----------------------------------------------------------------------------------------
        ///  <summary>
        ///  
        ///  </summary>
        ///  <param name="src"></param>
        ///  <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format, object[] args )
        {
            StringBuilder sb = src.AppendFormat( format );
            foreach ( var arg in args )
                sb.AppendFormat( format, arg );

            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format, object arg0 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat(this StringBuilder src, string format, object arg0, object arg1)
        {
            StringBuilder sb = src.AppendFormat(format, arg0, arg1);
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format, object arg0, object arg1, object arg2 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3, object arg4 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3, object arg4, object arg5 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4, arg5 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3,
                                                      object arg4, object arg5, object arg6 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4, arg5, arg6 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3,
                                                      object arg4, object arg5, object arg6, object arg7 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3, object arg4,
                                                      object arg5, object arg6, object arg7, object arg8 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="arg9"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3, object arg4,
                                                      object arg5, object arg6, object arg7, object arg8, object arg9 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="format"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="arg9"></param>
        /// <param name="arg10"></param>
        /// <returns></returns>
        public static StringBuilder AppendLineFormat( this StringBuilder src, string format,
                                                      object arg0, object arg1, object arg2, object arg3, object arg4, object arg5,
                                                      object arg6, object arg7, object arg8, object arg9, object arg10 )
        {
            StringBuilder sb = src.AppendFormat( format, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10 );
            sb.AppendLine();
            return sb;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Removes the line from the object, lineNumber is 0 based and lines are split on
        /// Environment.NewLine character.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="lineNumber">line number to be removed from StringBuilder object</param>
        /// <returns></returns>
        public static StringBuilder RemoveLine( this StringBuilder src, int lineNumber )
        {
            string[] lines = src.ToString().Split( new[] { Environment.NewLine }, StringSplitOptions.None );
            for ( int i = lineNumber; i < lines.Length - 1; i++ )
                lines[i] = lines[i + 1];

            src.Clear();
            src.Append( string.Join( Environment.NewLine, lines, 0, lines.Length - 1 ) );
            return src;
        }
    }
}
