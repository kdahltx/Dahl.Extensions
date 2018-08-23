using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dahl.Extensions.Tests
{
    public class Int32ExtTests
    {
        [TestClass]
        public class InSet_Method
        {
            [TestMethod]
            [DataRow(  1, 1, 99, true)]
            [DataRow(  2, 1, 99, true)]
            [DataRow( 98, 1, 99, true)]
            [DataRow( 99, 1, 99, true)]
            public void ValueInSet(int val, int minVal, int maxVal, bool expectedResult)
            {
                Assert.AreEqual( val.InSet(minVal,maxVal), expectedResult);
            }

            [TestMethod]
            [DataRow(-10, 1, 99, false)]
            [DataRow(  0, 1, 99, false)]
            [DataRow(100, 1, 99, false)]
            public void ValueNotInSet(int val, int minVal, int maxVal, bool expectedResult)
            {
                Assert.AreEqual(val.InSet(minVal, maxVal), expectedResult);
            }

            [TestMethod]
            [DataRow( 1, new[] { 1, 10, 15, 25 }, true)]
            [DataRow( 5, new[] { 1, 10, 15, 25 }, false)]
            [DataRow(10, new[] { 1, 10, 15, 25 }, true)]
            [DataRow(15, new[] { 1, 10, 15, 25 }, true)]
            [DataRow(16, new[] { 1, 10, 15, 25 }, false)]
            [DataRow(24, new[] { 1, 10, 15, 25 }, false)]
            [DataRow(25, new[] { 1, 10, 15, 25 }, true)]
            public void ValueInSets(int val, int[] set, bool expectedResult)
            {
                int[,] sets = new int[2,2];
                for ( int i = 0; i < set.Length; i += 2 )
                {
                    Assert.AreEqual( val.InSet( set ), expectedResult );
                }
            }

            [TestMethod]
            [DataRow(  0, "0..5,7,10..15", true)]
            [DataRow(  5, "0..5,7,10..15", true)]
            [DataRow(  6, "0..5,7,10..15", false)]
            [DataRow(  7, "0..5,7,10..15", true)]
            [DataRow(  9, "0..5,7,10..15", false)]
            [DataRow( 10, "0..5,7,10..15", true)]
            [DataRow( 12, "0..5,7,10..15", true)]
            [DataRow( 15, "0..5,7,10..15", true)]
            [DataRow( 16, "0..5,7,10..15", false)]
            public void ValueIn( int val, string set, bool expectedResult )
            {
                var result = val.In( set );
                Assert.AreEqual( result, expectedResult, $"set: [{set}]" );
            }
        }
    }
}
