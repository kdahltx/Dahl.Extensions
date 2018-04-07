using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dahl.Extensions;

namespace Dahl.Extensions.Tests
{
    public class StringExtTests
    {
        //-----------------------------------------------------------------------------------------
        [TestClass]
        public class TrimWhiteSpace_Method
        {
            [DataTestMethod]
            [DataRow( null, "" )]
            [DataRow( "", "" )]
            [DataRow( "    dog", "dog" )]
            [DataRow( "dog    ", "dog" )]
            [DataRow( "  dog  ", "dog" )]
            public void Trim( string value, string expected )
            {
                string actual = value.TrimWhiteSpace();
                Assert.AreEqual( expected, actual, "Values should be equal" );
            }
        }

        //-----------------------------------------------------------------------------------------
        [TestClass]
        public class ToInt32_Method
        {
            [DataTestMethod]
            [DataRow( "-2147483648", int.MinValue )]
            [DataRow( "-999999", -999999 )]
            [DataRow( "-1", -1 )]
            [DataRow( "0", 0 )]
            [DataRow( "1", 1 )]
            [DataRow( "999999", 999999 )]
            [DataRow( "2147483647", int.MaxValue )]
            public void ReturnEqualIntValue( string value, int expected )
            {
                int actual = value.ToInt32();
                Assert.AreEqual( expected, actual, "Values should be equal" );
            }

            [DataTestMethod]
            [DataRow( "-2147483649" )]
            [DataRow( "2147483648" )]
            public void ReturnDefaultValue( string value )
            {
                int actual = value.ToInt32();
                Assert.AreEqual( default( int ), actual, "Values should be equal" );
            }

            [DataTestMethod]
            [DataRow( "-2147483649" )]
            [DataRow( "2147483648" )]
            public void ReturnSpecifiedDefaultValue( string value )
            {
                int defaultValue = 10;
                int actual = value.ToInt32( defaultValue );
                Assert.AreEqual( defaultValue, actual, "Values should be equal" );
            }
        }

        //-----------------------------------------------------------------------------------------
        [TestClass]
        public class IntParse_Method
        {
        }

        [TestClass]
        public class EqualsIgnoreCase_Method
        {
        }

        [TestClass]
        public class NotEqual_Method
        {
        }

        [TestClass]
        public class NotEqualIgnoreCase_Method
        {
        }

        [TestClass]
        public class ContainsIgnoreCase_Method
        {
        }

        [TestClass]
        public class IsNullOrEmpty_Method
        {
        }

        [TestClass]
        public class IsNotNullOrEmpty_Method
        {
        }

        [TestClass]
        public class StartsWithIgnoreCase_Method
        {
        }

        [TestClass]
        public class EndsWithIgnoreCase_Method
        {
        }

        [TestClass]
        public class ReplaceIgnoreCase_Method
        {
        }

        [TestClass]
        public class ToString_Method
        {
        }

        [TestClass]
        public class ToEllipsis_Method
        {
        }

        [TestClass]
        public class ToGuid_Method
        {
        }

        [TestClass]
        public class ToDateTime_Method
        {
        }

        [TestClass]
        public class ToDate_Method
        {
        }

        [TestClass]
        public class IsDate_Method
        {
        }

        [TestClass]
        public class ToBool_Method
        {
        }

        [TestClass]
        public class ToInt16_Method
        {
        }

        [TestClass]
        public class ToInt64_Method
        {
        }

        [TestClass]
        public class ToDouble_Method
        {
        }

        [TestClass]
        public class ToFloat_Method
        {
        }

        [TestClass]
        public class ToDecimal_Method
        {
        }

        [TestClass]
        public class IsSsn_Method
        {
        }

        [TestClass]
        public class IsDigitsOnly_Method
        {
        }

        [TestClass]
        public class OnlyDigits_Method
        {
        }

        [TestClass]
        public class ToShortDateString_Method
        {
        }

        [TestClass]
        public class ToLongDateString_Method
        {
        }

        [TestClass]
        public class IsValidEmailFormat_Method
        {
        }

        [TestClass]
        public class FormatWithLineBreaks_Method
        {
        }

        [TestClass]
        public class AsPhoneNumber_Method
        {
        }

        [TestClass]
        public class AsSsn_Method
        {
        }

        [TestClass]
        public class RemoveLine_Method
        {
        }
    }
}
