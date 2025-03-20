using CsharpVersion14Sampl;
using CsharpVersion14Samples;

//-----------------------------------------------------------------------------------------------------
//What's new in C# 14
//https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14
//-----------------------------------------------------------------------------------------------------

Console.WriteLine("--- C# 14 New Features Demo ---\n");

//----------------------------------------------------------------------------------------------------
// 1. The 'field' keyword
//----------------------------------------------------------------------------------------------------

Console.WriteLine("--- 1. Field Keyword ---\n");
var sensor = new Sensor();
sensor.Temperature = 50.0;
Console.WriteLine($"Sensor Temperature: {sensor.Temperature}°C");

try
{
    sensor.Temperature = -500; // Invalid, triggers validation
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Validation Error: {ex.Message}");
}

Console.WriteLine();
//----------------------------------------------------------------------------------------------------


//----------------------------------------------------------------------------------------------------
// 2. Implicit Span Conversions
//
//C# 14 introduces first-class support for 'System.Span<T>' and 'System.ReadOnlySpan<T>' in the language. 
//----------------------------------------------------------------------------------------------------
Console.WriteLine("--- 2. Implicit Span Conversions ---\n");
byte[] buffer = { 10, 20, 30, 40 };
ImplicitSpanConversions.ProcessSpan(buffer);
Console.WriteLine();
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------
// 3. Unbound generic types and 'nameof'
//
//Beginning with C# 14, the argument to nameof can be an unbound generic type.
//For example, 'nameof(List<>)' evaluates to List. 
//In earlier versions of C#, only closed generic types, such as 'List<int>', 
//could be used to return the List name.
//
//----------------------------------------------------------------------------------------------------
Console.WriteLine("--- 3. nameof with Unbound Generic Types ---\n");
Console.WriteLine($"Unbound generic type name: {nameof(System.Collections.Generic.Dictionary<,>)}");
Console.WriteLine();
Console.WriteLine($"Unbound generic type name: {nameof(List<>)}");
Console.WriteLine();
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------
// 4. Simple lambda parameters with modifiers
//
//You can add parameter modifiers, such as 'scoped', 'ref', 'in', 'out', or 'ref readonly'
//to lambda expression parameters without specifying the parameter type.
//
//Legacy code:
//TryParse<int> parse2 = (string text, out int result) => Int32.TryParse(text, out result);
//
//New code:
//TryParse<int> parse1 = (text, out result) => Int32.TryParse(text, out result);
//----------------------------------------------------------------------------------------------------
Console.WriteLine("--- 4. Parameter Modifiers in Lambda Expressions ---\n");

// 4.1. Using 'ref' with Lambda Parameters
Console.WriteLine("--- 4.1. Lambda with 'ref' parameter ---");

Console.WriteLine("--- Sample1 ---");
var multiply = (ref int x, ref int y) => x * y;
int a = 5, b = 3;
Console.WriteLine($"Multiply using ref lambda: {multiply(ref a, ref b)}");
Console.WriteLine();

Console.WriteLine("--- Sample2 ---");
var increment = (ref int number) => number++;
int value = 10;
increment(ref value);
Console.WriteLine($"Incremented Value: {value}"); // Output: 11
Console.WriteLine();

// 4.2. Using 'out' with Lambda Parameters
Console.WriteLine("--- 4.2. Lambda with 'out' parameter ---");
var initialize = (out int number) => number = 42;
initialize(out int initializedValue);
Console.WriteLine($"Initialized Value: {initializedValue}"); // Output: 42
Console.WriteLine();

// 4.3. Using 'in' with Lambda Parameters
Console.WriteLine("---  4.3. Lambda with 'in' parameter (read-only) ---");
var printReadOnly = (in double num) => Console.WriteLine($"Read-only value: {num}");
double readOnlyValue = 100.5;
printReadOnly(in readOnlyValue); // Output: Read-only value: 100.5
Console.WriteLine();

// 4.4. Using 'ref readonly' with Lambda Parameters
Console.WriteLine("---  4.4. Lambda with 'ref readonly' parameter ---");
var showValue = (ref readonly int num) => Console.WriteLine($"Readonly Ref Value: {num}");
int readOnlyRefValue = 20;
showValue(ref readOnlyRefValue); // Output: Readonly Ref Value: 20
Console.WriteLine();

// 4.5. Using 'scoped' with Lambda Parameters
Console.WriteLine("--- 4.5. Lambda with 'scoped' modifier ---");
Span<int> numbers = stackalloc int[] { 1, 2, 3, 4 };
var sumSpan = (scoped Span<int> span) =>
{
    int sum = 0;
    foreach (var num in span)
        sum += num;
    return sum;
};
int total = sumSpan(numbers);
Console.WriteLine($"Sum of Span: {total}"); // Output: Sum of Span: 10
Console.WriteLine();

//----------------------------------------------------------------------------------------------------
// 5. Partial Constructor and Events
//
//A partial member has one declaring declaration and often one implementing declaration.
//The declaring declaration doesn't include a body.
//The implementing declaration provides the body of the member.
//
//----------------------------------------------------------------------------------------------------
//var employee = new Employee("Ada", "Lovelace");
//Console.WriteLine($"Employee created with name: {employee.FullName}");
//----------------------------------------------------------------------------------------------------





