# About

For teaching purposes


## Immutable collections .NET Core (C# 9)

**TODO**


## init-only setter
The main differences and similarities are described in this table:


|                      | Constructor parameter | `init` property |
|----------------------|-----------------------|-----------------|
|Since                 | C# 1.0                | [C# 9.0][1]     |
|Are required / Has hard guarantees about being present | Yes                   | No              |
|Self-documenting      | [Since C# 4.0][2]     | Yes             |
|Can overwrite `readonly` fields| Yes | Yes |
|Suitable for          | Required and optional values       | Optional values |
|Ease of reflection    | Just use `ConstructorInfo`     | Horrible |
|Supported by [MEDI][3]| Yes                   | No              |
|[Breaks `IDisposable`][4]| No                    | Yes             |
|Class knows init order| Yes                   | No              |
|Ergonomics when subclassing| Tedious|Decent|

The downsides of `init` are mostly inherited from the downsides of C#'s object-initializer expressions which still have numerous issues (in the footnote).

As for when you should vs. shouldn't:

* Don't use `init` properties for required values - use a constructor parameter instead.
* _Do_ use `init` properties for nonessential, non-required, or otherwise optional values that when set via individual properties do not invalidate the object's state.

------

* In short, `init` properties make it _slightly easier_ to initialize nonessential properties in immutable types - however they also make it easier to shoot yourself in the foot if you're using `init` for _required_ members instead of using a constructor parameter, _especially_ C# 8.0 nullable-reference-types (as there's no guarantees that a non-nullable reference-type property will ever be assigned).
* In terms of guidance:
  * If your `class` is not immutable, or at least does not employ immutable-semantics on certain properties then you don't need to use `init` on those properties.
  * If it's a `struct` then don't use `init` properties at all, due to all the small details in `struct` copy behavior.
  * In my opinion (not shared by everyone else), I recommend you consider an optional (could also be nullable) constructor parameter or an entire different constructor overload instead of `init` properties given the problems I feel they have and lack of any real advantages.

------

Footnote: Problems with C# object-initializer syntax, inherited by `init` properties:

* [Breaks debugging][5]: Even in C# 9, if any line of the initializer throws an exception then the exception's `StackTrace` will be the same line as the `new` statement instead of the line of the sub-expression that caused the exception.
* [Breaks `IDisposable`][4]: if a property-setter (or initialization expression) throws an exception and _if_ the type implements `IDisposable` then the newly created instance will not be disposed-of, even though the constructor completed (and the object is fully initialized as far as the CLR is concerned).


  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
  [3]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection?view=dotnet-plat-ext-6.0
  [4]: https://stackoverflow.com/questions/6409918/object-initializer-and-dispose-when-property-can-throw-exception
  [5]: https://stackoverflow.com/questions/40768906/cannot-identify-the-property-which-throw-exception-when-using-object-initializer

## Struct

In .NET, there are two categories of types, `reference types` and `value types`.

`Structs` are `value types` and `classes` are `reference types`.

The general difference is that a reference type lives on the heap, and a value type lives inline, that is, wherever it is your variable or field is defined.

A variable containing a value type contains the entire value type value. For a struct, that means that the variable contains the entire struct, with all its fields.

A variable containing a reference type contains a pointer, or a reference to somewhere else in memory where the actual value resides.

This has one benefit, to begin with:

- `value types` always contains a value
- `reference types` can contain a null-reference, meaning that they don't refer to anything at all at the moment


Internally, reference types are implemented as pointers, and knowing that, and knowing how variable assignment works, there are other behavioral patterns:


- Copying the contents of a value type variable into another variable, copies the entire contents into the new variable, making the two distinct. In other words, after the copy, changes to one won't affect the other
- Copying the contents of a reference type variable into another variable, copies the reference, which means you now have two references to the same somewhere else storage of the actual data. In other words, after the copy, changing the data in one reference will appear to affect the other as well, but only because you're really just looking at the same data both places

## Difference between Structs and Classes:

![img](assets/StructClass1.png)

![img](StructConsoleApp/assets/StructClass.png)
