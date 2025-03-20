# Csharp Version14 New Features

## 1. The 'field' keyword

The token 'field' enables you to write a property accessor body without declaring an explicit backing field.
The token 'field' is replaced with a compiler synthesized backing field.

Legacy code:

´´´csharp
private string _msg;
public string Message
{
  get => _msg;
  set => _msg = value ?? throw new ArgumentNullException(nameof(value));
}
´´´

New code:

´´´csharp
public string Message
{
  get;
  set => field = value ?? throw new ArgumentNullException(nameof(value));
}
´´´
