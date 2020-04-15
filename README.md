Dahl.Data - .NET Extension methods for string, Dictionary, int, Linq, Property, StringBuilder
========================================

[![Build Status](https://dev.azure.com/Dahl.Extensions/_apis/build/status/Dahl.Extensions?branchName=master)](https://dev.azure.com/Dahl.Extensions/_build/latest?definitionId=4&branchName=master)

![Nuget](https://img.shields.io/nuget/v/blazored.modal.svg)

Release Notes
-------------
Located at [kdahltx/Dahl.Extensions](https://github.com/kdahltx/Data.Extensions)

Packages
--------


| Package | NuGet Stable |
| ------- | ------------ |
| [Dahl.Extensions](https://www.nuget.org/packages/Dahl.Extensions/) | [![Dahl.Extensions](https://img.shields.io/nuget/Dahl.Extensions)](https://www.nuget.org/packages/Dahl.Extensions/) |


Features
--------
Dahl.Extensions is a [NuGet library](https://www.nuget.org/packages/Dahl.Extensions)
you use in your project to help make your code easier to write and read.

Example usage: Test for null or empty string
```csharp
string userName;

//---------------------------------------------
// check userName for NOT being null or empty.
// uses .NET static method
if (!string.IsNullOrEmpty(userName) )
    doSomething();

// uses extension library.
if ( userName.IsNotNullOrEmpty() )
    doSomething();

//---------------------------------------------
// check userName for being null or empty.
// uses .NET static method
if (string.IsNullOrEmpty(userName) )
    doSomething();

// uses extension library.
if ( userName.IsNullOrEmpty() )
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

// handles exceptions and returns a default value if
// the string is null or an invalid value.
int val = num.ToInt32();
```

