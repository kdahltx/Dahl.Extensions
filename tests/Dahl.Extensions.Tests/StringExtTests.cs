using System.ComponentModel;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dahl.Extensions;

namespace Dahl.Extensions.Tests
{
    [TestClass]
    public class StringExtTests
    {
        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [DataTestMethod]
        [DataRow( null,      "" )]
        [DataRow( "",        "" )]
        [DataRow( "    dog", "dog" )]
        [DataRow( "dog    ", "dog" )]
        [DataRow( "  dog  ", "dog" )]
        public void TrimWhiteSpace( string value, string expected )
        {
            string actual = value.TrimWhiteSpace();
            Assert.AreEqual( expected, actual, "Values should be equal" );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [DataTestMethod]
        [DataRow( "-2147483648", int.MinValue )]
        [DataRow( "-999999",     -999999 )]
        [DataRow( "-1",          -1 )]
        [DataRow( "0",           0 )]
        [DataRow( "1",           1 )]
        [DataRow( "999999",      999999 )]
        [DataRow( "2147483647",  int.MaxValue )]
        public void ConvertStringToInt( string value, int expected )
        {
            int actual = value.ToInt32();
            Assert.AreEqual( expected, actual, "Values should be equal" );
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow( "-2147483649" )]
        [DataRow( "2147483648" )]
        public void ConvertStringToIntReturnsDefaultIntValue( string value )
        {
            int actual = value.ToInt32();
            Assert.AreEqual( default, actual, "Values should be equal" );
        }

        ///----------------------------------------------------------------------------------------
        /// 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow( "-2147483649" )]
        [DataRow( "2147483648" )]
        public void ConvertStringToIntReturnsSpecifiedDefaultValue( string value )
        {
            int defaultValue = 10;
            int actual       = value.ToInt32( defaultValue );
            Assert.AreEqual( defaultValue, actual, "Values should be equal" );
        }

        [DataTestMethod]
        [DataRow("-2147483649", false)]
        [DataRow("2147483648", false)]
        [DataRow("-2147483648", true)]
        [DataRow("2147483647", true)]
        public void TryParseInt(string value, bool isValid)
        {
            int actual = value.IntParse();
            if (isValid)
            {
                if (int.TryParse(value, out var expected))
                    Assert.AreEqual(expected, actual);
                else
                    Assert.Fail();
            }
            else
            {
                if (!int.TryParse(value, out var expected))
                    Assert.AreEqual(expected, actual);
                else
                    Assert.Fail();
            }
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [DataTestMethod]
        [DataRow("aBcdefg", "Abcdefg", true)]
        [DataRow("abCdefg", "aBcdefg", true)]
        [DataRow("abcdeFG", "abcdefG", true)]
        [DataRow("abcdefg", "abcdef", false)]
        [DataRow("abcdefg", "AAcdefg", false)]
        [DataRow("abcdefg", "abcdegg", false)]
        public void EqualsIgnoreCase(string value1, string value2, bool expectedResult)
        {
            bool actualResult = value1.EqualsIgnoreCase(value2);
            Assert.AreEqual(actualResult, expectedResult);
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [DataTestMethod]
        [DataRow("aBcdefg", "Abcdefg", false)]
        [DataRow("abcdeFG", "abcdefG", false)]
        [DataRow("abcdefg", "abcdef", true)]
        [DataRow("abcdefg", "AAcdefg", true)]
        [DataRow("abcdefg", "abcdegg", true)]
        public void NotEqualIgnoreCase(string value1, string value2, bool expectedResult)
        {
            bool actualResult = value1.NotEqualIgnoreCase(value2);
            Assert.AreEqual(actualResult, expectedResult);
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [DataTestMethod]
        [DataRow("abcdefg", "abcdefg", false)]
        [DataRow("aBcdefg", "Abcdefg", true)]
        [DataRow("abcdeFG", "abcdefG", true)]
        [DataRow("abcdefg", "abcdef", true)]
        [DataRow("abcdefg", "AAcdefg", true)]
        [DataRow("abcdefg", "abcdegg", true)]
        public void NotEqual(string value1, string value2, bool expectedResult)
        {
            bool actualResult = value1.NotEqual(value2);
            Assert.AreEqual(actualResult, expectedResult);
        }

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ContainsIgnoreCase()
        {}

        ///----------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsNullOrEmpty()
        {}

        [TestMethod]
        public void IsNotNullOrEmpty()
        {}

        [TestMethod]
        public void StartsWithIgnoreCase()
        {}

        [TestMethod]
        public void EndsWithIgnoreCase()
        {}

        [TestMethod]
        public void ReplaceIgnoreCase()
        {}

        [DataTestMethod]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 7, 7 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 6, 6 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 5, 5 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 4, 4 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 3, 3 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 2, 3 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 1, 3 )]
        [DataRow( "abcdefghijklmnopqrstuvwxyz", 0, 3 )]
        public void ReturnStringWithElipsis( string value, int len, int expectedLen )
        {
            var newValue = value.ToEllipsis( len );
            Trace.WriteLine( $"value: [{value}], newValue: [{newValue}], expected length: [{len}], actual length: [{newValue.Length}]" );
            Assert.AreEqual( newValue.Length, expectedLen );
        }

        [TestMethod]
        public void ToGuid()
        {}

        [TestMethod]
        public void ToDateTime()
        {}

        [TestMethod]
        public void ToDate()
        {}

        [TestMethod]
        public void IsDate()
        {}

        [TestMethod]
        public void ToBool()
        {}

        [TestMethod]
        public void ToInt16()
        {}

        [TestMethod]
        public void ToInt64()
        {}

        [TestMethod]
        public void ToDouble()
        {}

        [TestMethod]
        public void ToFloat()
        {}

        [TestMethod]
        public void ToDecimal()
        {}

        [TestMethod]
        public void IsSsn()
        {}

        [TestMethod]
        public void IsDigitsOnly()
        {}

        [TestMethod]
        public void OnlyDigits()
        {}

        [TestMethod]
        public void ToShortDateString()
        {}

        [TestMethod]
        public void ToLongDateString()
        {}

        [TestMethod]
        public void IsValidEmailFormat()
        {}

        [TestMethod]
        public void FormatWithLineBreaks()
        {}

        [TestMethod]
        public void AsPhoneNumber()
        {}

        [TestMethod]
        public void AsSsn()
        {}

        [TestMethod]
        public void RemoveLine()
        {}
    }
}
