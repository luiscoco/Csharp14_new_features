# Csharp Version14 New Features

## 1. The 'field' keyword

The token 'field' enables you to write a property accessor body without declaring an explicit backing field.
The token 'field' is replaced with a compiler synthesized backing field.

Legacy code:

```csharp
private string _msg;
public string Message
{
  get => _msg;
  set => _msg = value ?? throw new ArgumentNullException(nameof(value));
}
```

New C# v14 code:

```csharp
public string Message
{
  get;
  set => field = value ?? throw new ArgumentNullException(nameof(value));
}
```

See in detail the sample code provided:

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
