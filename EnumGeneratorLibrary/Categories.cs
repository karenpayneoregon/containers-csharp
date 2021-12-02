using System.CodeDom.Compiler;
using System.ComponentModel;

namespace EnumGeneratorLibrary
{
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
}
