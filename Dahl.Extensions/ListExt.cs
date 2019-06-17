using System.Collections.Generic;
using System.ComponentModel;

namespace Dahl.Extensions
{
    public static class ListExt
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="startsWith"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase( this BindingList<string> src, string startsWith )
        {
            if ( src == null )
                return false;

            foreach ( string s in src )
            {
                if ( s.StartsWithIgnoreCase( startsWith ) )
                    return true;
            }

            return false;
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="startsWith"></param>
        /// <returns></returns>
        public static List<int> StartsWithIgnoreCaseIndexList( this BindingList<string> src, string startsWith )
        {
            List<int> indexList = new List<int>();

            if (src == null )
                return indexList;

            for ( int i = 0; i < src.Count; i++ )
            {
                if ( src[i].StartsWithIgnoreCase( startsWith ) )
                    indexList.Add( i );
            }

            return indexList;
        }
    }
}
