using System;
using System.Linq;

namespace Dahl.Extensions
{
    public static class Int32Ext
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// returns true or false if the integer value is between the min & max values inclusive
        /// </summary>
        /// <param name="src"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static bool InSet( this int src, int minValue, int maxValue )
        {
            return minValue <= src && src <= maxValue;
        }

#pragma warning disable 1570
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// return true if the value falls between one of the sets of values inclusive
        /// example usage: i.InSet( new[,]{{1,254},{310,369},{402,799}} )
        ///                if 1 &lt= i && i &lt= 254 or 310 &lt= i && i &lt= 369 or 402 &lt= i && i &lt= 799 then return true
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sets"></param>
        /// <returns></returns>
#pragma warning restore 1570
        public static bool InSet( this int src, int[,] sets )
        {
            int len = sets.Length / 2;
            for ( int i = 0; i < len; i++ )
            {
                if ( src.InSet( sets[i, 0], sets[i, 1] ) )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Use this to check a series of int values.
        /// example usage: i.InSet( new[] {1,2,5,6,8,10} )
        /// </summary>
        /// <param name="src"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static bool InSet( this int src, int[] set )
        {
            return set.Any( i => src == i );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// Example usage: intValue.In("1,5..10,15,16,20..25");
        /// </summary>
        /// <param name="src"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public static bool In( this int src, string set )
        {
            string[] subSets = set.Trim().Split(',');
            foreach ( string s in subSets )
            {
                var range = s.Split(new[] { ".." }, StringSplitOptions.RemoveEmptyEntries);
                if ( range.Length == 1 )
                {
                    var val1 = range[0].ToInt32();
                    if ( src == val1 )
                        return true;
                }
                else if ( range.Length == 2 )
                {
                    var lo = range[0].ToInt32();
                    var hi = range[1].ToInt32();
                    if ( lo <= src && src <= hi )
                        return true;
                }
            }

            return false;
        }

        public static int[] Add( this int[] src, int value )
        {
            if ( src == null )
                return null;

            var list = src.ToList();
            list.Add( value );
            src = list.ToArray();

            return src;
        }
    }
}
