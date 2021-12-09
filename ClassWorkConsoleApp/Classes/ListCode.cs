using System.Collections.Generic;
using ClassWorkConsoleApp.Interfaces;
using CommonLibrary.Classes.Generics;

namespace ClassWorkConsoleApp.Classes
{
    public class ListCode : IBaseMethods
    {
        public void Basics()
        {
            List<Country> mutableList = new List<Country>() {new() {Id = -1, Name = "Select"} };
            mutableList.Add(new () {Id = 1, Name = "Canada"});
            mutableList.Add(new () {Id = 2, Name = "USA"});

            mutableList[0].Name = "";

            IReadOnlyList<CountryItem> list = new List<CountryItem>()
            {
                new (-1, "Select"),
                new (1, "Canada"),
                new (2, "USA")
            };

            //list[0].Name = "";

        }

        public IReadOnlyList<CountryItem> Countries => new List<CountryItem>()
        {
            new(-1, "Select"),
            new(1, "Canada"),
            new(2, "USA")
        };
}

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;

    }
    public class CountryItem
    {
        public int Id { get; }
        public string Name { get; }
        public override string ToString() => Name;

        public CountryItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}