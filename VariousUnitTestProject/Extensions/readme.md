# About

Shows what happens when AllInt is not properly tested.

NumericExtensions1, NumericExtensions2 have same methods, one ill coded.

Does not account for null elements

```csharp
public static bool AllInt(this string[] sender)
    => sender.SelectMany(item => item.ToCharArray()).All(char.IsNumber);
```

Perhaps a null check?

```csharp
public static bool HasNullValues(this string[] sender) => sender.Any(string.IsNullOrWhiteSpace);
```

Or all in one?

```csharp
public static bool AllInt(this string[] sender) =>
    !sender
        .Any(string.IsNullOrWhiteSpace) && sender.SelectMany(item => item.ToCharArray())
        .All(@char => !string.IsNullOrWhiteSpace(@char.ToString()) && char.IsDigit(@char));
```

Is the last method inefficient because we converted a `char` to a `string`? If working against a small array, no.

