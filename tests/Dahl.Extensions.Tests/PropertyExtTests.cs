using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dahl.Extensions.Tests
{
    public class PropertyTestMethods
    {
        public bool GetAccessorList_Method()
        {
            int i = 0;

            IPropertyAccessor[] accessors = typeof( TestClass ).GetAccessorList();
            foreach ( var item in TestClassList )
            {
                var expected = ExpectedList[i++];
                foreach ( var accessor in accessors )
                {
                    var propertyName = accessor.PropertyInfo.Name;

                    // use this for setter testing
                    Type pt = accessor.PropertyInfo.PropertyType;
                    if ( propertyName.EqualsIgnoreCase( "Id" ) )
                        accessor.SetValue( item, expected.Id );
                    else if ( propertyName.EqualsIgnoreCase( "FirstName" ) )
                        accessor.SetValue( item, expected.FirstName );
                    else if ( propertyName.EqualsIgnoreCase( "LastName" ) )
                        accessor.SetValue( item, expected.LastName );
                    else if ( propertyName.EqualsIgnoreCase( "Age" ) )
                        accessor.SetValue( item, expected.Age );

                    var propertyValue = accessor.GetValue( item );
                    Trace.Write( $"{propertyName}:{propertyValue}," );

                    if ( propertyName.EqualsIgnoreCase( "Id" ) )
                        Assert.AreEqual( item.Id, expected.Id );
                    else if ( propertyName.EqualsIgnoreCase( "FirstName" ) )
                        Assert.AreEqual( item.FirstName, expected.FirstName );
                    else if ( propertyName.EqualsIgnoreCase( "LastName" ) )
                        Assert.AreEqual( item.LastName, expected.LastName );
                    else if ( propertyName.EqualsIgnoreCase( "Age" ) )
                        Assert.AreEqual( item.Age, expected.Age );
                }
                Trace.WriteLine( "" );
            }

            Trace.WriteLine( "Test Passed" );
            return true;
        }

        //-----------------------------------------------------------------------------------------
        private static readonly List<TestClass> TestClassList = new List<TestClass>
        {
            new TestClass { Id = 1, FirstName  = "FirstName01", LastName = "LastName01", Age = 51 },
            new TestClass { Id = 2, FirstName  = "FirstName02", LastName = "LastName02", Age = 52 },
            new TestClass { Id = 3, FirstName  = "FirstName03", LastName = "LastName03", Age = 53 },
            new TestClass { Id = 4, FirstName  = "FirstName04", LastName = "LastName04", Age = 54 },
            new TestClass { Id = 5, FirstName  = "FirstName05", LastName = "LastName05", Age = 55 },
            new TestClass { Id = 6, FirstName  = "FirstName06", LastName = "LastName06", Age = 56 },
            new TestClass { Id = 7, FirstName  = "FirstName07", LastName = "LastName07", Age = 57 },
            new TestClass { Id = 8, FirstName  = "FirstName08", LastName = "LastName08", Age = 58 },
            new TestClass { Id = 9, FirstName  = "FirstName09", LastName = "LastName09", Age = 59 },
            new TestClass { Id = 10, FirstName = "FirstName10", LastName = "LastName10", Age = 60 },
        };

        private static readonly List<TestClass> ExpectedList = new List<TestClass>
        {
            new TestClass { TestClassId = 101, FirstName = "FirstName101", LastName = "LastName101", Age = 21 },
            new TestClass { TestClassId = 102, FirstName = "FirstName102", LastName = "LastName102", Age = 22 },
            new TestClass { TestClassId = 103, FirstName = "FirstName103", LastName = "LastName103", Age = 23 },
            new TestClass { TestClassId = 104, FirstName = "FirstName104", LastName = "LastName104", Age = 24 },
            new TestClass { TestClassId = 105, FirstName = "FirstName105", LastName = "LastName105", Age = 25 },
            new TestClass { TestClassId = 106, FirstName = "FirstName106", LastName = "LastName106", Age = 26 },
            new TestClass { TestClassId = 107, FirstName = "FirstName107", LastName = "LastName107", Age = 27 },
            new TestClass { TestClassId = 108, FirstName = "FirstName108", LastName = "LastName108", Age = 28 },
            new TestClass { TestClassId = 109, FirstName = "FirstName109", LastName = "LastName109", Age = 29 },
            new TestClass { TestClassId = 110, FirstName = "FirstName110", LastName = "LastName110", Age = 30 }
        };
    }

    public class BaseTest<TPKey>
    {
        public TPKey Id { get; set; }
    }

    public class TestClass : BaseTest<int>
    {
        public int    TestClassId { get { return Id; } set { Id = value; } }
        public string FirstName   { get;               set; }
        public string LastName    { get;               set; }
        public int    Age         { get;               set; }
    }
}
