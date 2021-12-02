Code to create enum from SQL-Server reference table. In this project the database is NorthWind found under the Scripts folder.

**See also**: 

- EnumDescriptionExample project
- Microsoft TechNet [Entity Framework database/Code First Enum support](https://social.technet.microsoft.com/wiki/contents/articles/53169.entity-framework-databasecode-first-enum-support.aspx)

- For instructions see Microsoft TechNet article [Entity Framework database/Code First Enum support](https://social.technet.microsoft.com/wiki/contents/articles/53169.entity-framework-databasecode-first-enum-support.aspx#Creating_Enum_for_reference_table).
  - The code presented here is slightly different than the article where instead of having XML comments for each member this version does [Description](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.descriptionattribute?view=net-5.0) attribute.

# Example 1

In the following example there is a description column which is use for the `Description` attribute while the second example does not have a description column.

```csharp
[GeneratedCode("TextTemplatingFileGenerator", "10")]
public enum Categories
{

    [Description("Soft drinks, coffees, teas, beers, and ales")]
    Beverages = 1,
    [Description("Sweet and savory sauces, relishes, spreads, and seasonings")]
    Condiments = 2,
    [Description("Desserts, candies, and sweet breads")]
    Confections = 3,
    [Description("Cheeses")]
    DairyProducts = 4,
    [Description("Breads, crackers, pasta, and cereal")]
    GrainsCereals = 5,
    [Description("Prepared meats")]
    MeatPoultry = 6,
    [Description("Dried fruit and bean curd")]
    Produce = 7,
    [Description("Seaweed and fish")]
    Seafood = 8,
    [Description("Wine")]
    Wine = 9
}
```

# Example 2

No description column, instead each member is split a upper case characters

```csharp
public enum ContactType
{

    [Description("Accounting Manager")]
    AccountingManager = 1,
    [Description("Assistant Sales Agent")]
    AssistantSalesAgent = 2,
    [Description("Assistant Sales Representative")]
    AssistantSalesRepresentative = 3,
    [Description("Marketing Assistant")]
    MarketingAssistant = 4,
    [Description("Marketing Manager")]
    MarketingManager = 5,
    [Description("Order Administrator")]
    OrderAdministrator = 6,
    [Description("Owner")]
    Owner = 7,
    [Description("Owner/Marketing Assistant")]
    OwnerMarketingAssistant = 8,
    [Description("Sales Agent")]
    SalesAgent = 9,
    [Description("Sales Associate")]
    SalesAssociate = 10,
    [Description("Sales Manager")]
    SalesManager = 11,
    [Description("Sales Representative")]
    SalesRepresentative = 12,
    [Description("Vice President, Sales")]
    VicePresidentSales = 13
}
```