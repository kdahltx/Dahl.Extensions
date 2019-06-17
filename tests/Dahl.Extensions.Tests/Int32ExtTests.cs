using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dahl.Extensions.Tests
{
    public class Int32ExtTests
    {
        public bool ValueInSet( int val, int minVal, int maxVal, bool expectedResult )
        {
            return val.InSet( minVal, maxVal ) == expectedResult;
        }

        public bool ValueNotInSet( int val, int minVal, int maxVal, bool expectedResult )
        {
            return val.InSet( minVal, maxVal ) == expectedResult;
        }

        public bool ValueInSets( int val, int[] set, bool expectedResult )
        {
            for ( int i = 0; i < set.Length; i += 2 )
            {
                if ( val.InSet( set ) != expectedResult )
                    return false;
            }

            return true;
        }

        public bool ValueIn( int val, string set, bool expectedResult )
        {
            return val.In( set ) == expectedResult;
        }
    }
}
