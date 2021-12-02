# About

Enumerations provide constant values generally used in program logic such as if statements.  They can also be used as a type when working with changing a data type from a integer to an enum with Entity Framework Core or used in a user interface for users to select options.

```csharp
public enum Categories
{
    Beverages,
    DairyProducts,
    GrainsCereals,
    Produce
}
```

Using the enum above in a user interface (web or desktop) would not be very professional looking. Instead we can declarate enum members with an attribute.

```csharp
public enum Categories
{
    [Description("Soft drinks, coffees, teas")]
    Beverages,
    [Description("Cheeses")]
    DairyProducts,
    [Description("Breads, crackers, pasta, and cereal")]
    GrainsCereals,
    [Description("Dried fruit and bean curd")]
    Produce
}
```

When presented in a dropdown (web or desktop) the description is shown rather than the enum. Then to get the user's selection use an extension method to get the actual enum.

```csharp
public static (string text, Categories category) CurrentCategory(this ListControl source)
    => (source.Text, (Categories)source.SelectedValue);
```

# But those enums are hard-coded

Next level is to generate the enum on each build using a [T4](https://docs.microsoft.com/en-us/visualstudio/modeling/code-generation-and-t4-text-templates?view=vs-2022) Text Template.

Creating and maintaining these templates takes different skills then writing business logic along with Visual Studio does not help much with coding these templates.

Check out the code in this project EnumGeneratorLibrary which reads from a SQL-Server database table(s) to generate enums with [Description attribute](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.descriptionattribute?view=net-6.0).

Once generated drop the class created into a project. 

Going down the rabbit hole this process can be automated but that is an advance topic which requires yet a different programming skill I will get into in a future class.