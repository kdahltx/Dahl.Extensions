Dahl.Data - .NET Extension methods for string, Dictionary, int, Linq, Property, StringBuilder
========================================


Release Notes
-------------
Located at [kdahltx/Dahl.Data](https://github.com/kdahltx/Data.Data)

Packages
--------


| Package | NuGet Stable |
| ------- | ------------ |
| [Dahl.Extensions](https://www.nuget.org/packages/Dahl.Extensions/) | [![Dahl.Extensions](https://img.shields.io/nuget/Dahl.Extensions)](https://www.nuget.org/packages/Dahl.Extensions/) |


Features
--------
Dahl.Data is a [NuGet library](https://www.nuget.org/packages/Dahl.Data) that you can add in to
your project to use extension methods to write code that is easier to write and read.

Example usage: Test for null or empty string
```csharp
string userName;

if ( userName.IsNotNullOrEmpty() )
    doSomething();

if ( userName.IsNullOrEmpty() )
    doSomething();

if ( userName.EqualsIgnoreCase( "aBc" ) )
    doSomething();


```
Example usage: Compares ignoring case
```csharp
string value1 = "john";
string value2 = "John";

if ( value1.EqualsIgnoreCase( value2 ) )
    doSomething();

// check for valid ssn
string ssn = "111-23-1454"
if ( value1.IsSsn() )
    doSomething();

// add ellipsis to end of string specifying max length
string sentence = "this is a long sentence to where we want to add an ellipsis";
sentence = sentence.ToEllipsis( 7 );
// produces the string "this..."

```

Example usage: Convert a string value to integer
```csharp
string num = "123";
int val = num.ToInt32();
```

