# Csharp Version 14 New Features

## 1. The 'field' keyword

The token **field** enables you to write a property accessor body without declaring an explicit backing field.

The token **field** is replaced with a compiler synthesized backing field.

**Legacy code**:

```csharp
private string _msg;
public string Message
{
  get => _msg;
  set => _msg = value ?? throw new ArgumentNullException(nameof(value));
}
```

**New C# v14 code**:

```csharp
public string Message
{
  get;
  set => field = value ?? throw new ArgumentNullException(nameof(value));
}
```

Now see another more complex sample about this new feature in C# 14:

```csharp
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
```

And also we have to define the **Sensor** class

```csharp
public class Sensor
{
    public double Temperature
    {
        get;
        set => field = (value < -273.15)
            ? throw new ArgumentOutOfRangeException(nameof(value), "Temperature cannot be below absolute zero.")
            : value;
    }
}
```

## 2. Implicit Span Conversions

C# 14 introduces first-class support for **System.Span<T>** and **System.ReadOnlySpan<T>** in the language. 

See this sample:

```csharp
Console.WriteLine("--- 2. Implicit Span Conversions ---\n");
byte[] buffer = { 10, 20, 30, 40 };
ImplicitSpanConversions.ProcessSpan(buffer);
Console.WriteLine();
```

```csharp
 public class ImplicitSpanConversions
 {
     public static void ProcessSpan(Span<byte> data)
     {
         Console.WriteLine("Processing Array Data:");
         foreach (var b in data)
             Console.WriteLine(b);
     }

     public static void ProcessSpan(ReadOnlySpan<byte> data)
     {
         Console.WriteLine("Processing Span Data:");
         foreach (var b in data)
             Console.WriteLine(b);
     }
 }
```

## 3. Unbound generic types and 'nameof'

Beginning with C# 14, the argument to nameof can be an unbound generic type.

For example, **nameof(List<>)** evaluates to List. 

In earlier versions of C#, only closed generic types, such as **List<int>**, could be used to return the List name.

```csharp
Console.WriteLine("--- 3. nameof with Unbound Generic Types ---\n");
Console.WriteLine($"Unbound generic type name: {nameof(System.Collections.Generic.Dictionary<,>)}");
Console.WriteLine();
Console.WriteLine($"Unbound generic type name: {nameof(List<>)}");
Console.WriteLine();
```

## 4. Simple lambda parameters with modifiers

You can add parameter modifiers, such as **scoped**, **ref**, **in**, **out**, or **ref readonly** to lambda expression parameters without specifying the parameter type.

**Legacy code**:

```csharp
TryParse<int> parse2 = (string text, out int result) => Int32.TryParse(text, out result);
```

**New C# 14 code**:

```csharp
TryParse<int> parse1 = (text, out result) => Int32.TryParse(text, out result);
```
