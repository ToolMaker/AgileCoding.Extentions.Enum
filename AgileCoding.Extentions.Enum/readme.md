# AgileCoding.Extensions.Enums NuGet Package

This NuGet package offers a range of helpful extension methods to work with enums in .NET applications.

## Features

The `EnumExtension` static class provides several methods for enhancing the functionality and versatility of enums in your application:

- `SetWithStringValue<EnumType>()`: Set an enum with a string value.
- `SetWithStringValue<EnumType, IExceptionType>()`: Set an enum with a string value and provide an error message if an error occurs.
- `ValidateEnumEqualToAny<TEnum, IExceptionType>()`: Validates if an enum is equal to any value from a given list of enums.
- `InAny<TEnum>()`: Checks if an enum exists in a given list of enums.
- `ThrowIfEqualTo<TEnum, IExceptionType>()`: Throws an exception if the enum is equal to a specific value.
- `GetAllEnumsContainingAttribute<ANYType>()`: Returns all enums containing a specified attribute value.

## How to Use

Here's a simple example of how to use the `SetWithStringValue<EnumType>()` method:

```csharp
using AgileCoding.Extentions.Enums;

public enum MyEnum
{
    Value1,
    Value2
}

// To use the extension method:
MyEnum myEnum = MyEnum.Value1;
myEnum = myEnum.SetWithStringValue("Value2");
```
