﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CommonLibrary.Classes;
using CommonLibrary.LanguageExtensions;
using Microsoft.AspNetCore.WebUtilities;
using ThirdPartyLibrary.Classes;
using ThirdPartyLibrary.Models;

namespace DictionaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicSample();
        }

        /// <summary>
        /// Using a Dictionary create a url with params
        /// </summary>
        private static void AlreadyCompleted()
        {
            string language = "S";

            Dictionary<string, string> queryArguments = new() { { "transId", "64440952" }, { "lang", "E" } };

            if (language == "S")
            {
                queryArguments["lang"] = language;
            }


            var results = QueryHelpers.AddQueryString("advisoryNotice.cfm", queryArguments);

            // expected advisoryNotice.cfm?transId=64440952&lang=S
            Debug.WriteLine(results);

            Debug.WriteLine("");

            queryArguments = new Dictionary<string, string>()
            {
                { "static-argument", "foo" },
            };

            if (true) // bogus
            {
                queryArguments.Add("dynamic-argument", "bar");
            }

            results = QueryHelpers.AddQueryString("/example/path", queryArguments);
            Debug.WriteLine(results);
            Debug.WriteLine("");

            queryArguments = new Dictionary<string, string>()
            {
                {"dog", "221" },
                {"gender", "female" },
                {"age","4,5,6" }
            };

            results = QueryHelpers.AddQueryString("/api/product/list", queryArguments);
            Debug.WriteLine(results);

            


        }

        /// <summary>
        /// Dictionary where Key is a person's name, Value is birthday
        /// Iterate the Dictionary, display person's name and age.
        /// </summary>
        private static void BasicSample()
        {
            string name = "Jane Doe";

            Dictionary<string, DateTime> users = new()
            {
                { "John Doe", new DateTime(1956, 3, 12) },
                { "Jane Doe", new DateTime(2000, 5, 29) },
                { "Joe Doe", new DateTime(1962, 11, 5) },
                { "Jenna Doe", new DateTime(1985, 10, 2) }
            };

            // since name exists nothing is added
            if (!users.ContainsKey(name))
            {
                users.Add(name, new DateTime(1956, 9, 24));
            }

            name = "Karen Payne";
            // name does not exists, add it
            if (!users.ContainsKey(name))
            {
                users.Add(name, new DateTime(1956, 9, 24));
            }

            name = "Vince Buchheit";
            users.AddSafe(name, new DateTime(1950, 2, 2));
            users.AddSafe(name, new DateTime(1950, 2, 2));


            Debug.WriteLine("");

            foreach (KeyValuePair<string, DateTime> user in users.OrderBy(user => user.Value))
            {
                Debug.WriteLine($"{user.Key, -18} is {user.Value.Age(DateTime.Now).YearsMonthsDays} old");
            }

            Debug.WriteLine("");

        }

        /// <summary>
        /// Example which uses <see cref="Departments"/> and creates a Dictionary with the Id as Key and Name as Value
        /// </summary>
        private static void ListToDictionary()
        {

            Dictionary<int, string> departmentDictionary = 
                References.DepartmentEditableList.ToDictionary(department => 
                    department.Id, department => department.Name);

            foreach (var kvp in departmentDictionary)
            {
                Debug.WriteLine($"{kvp.Key,-3:D2}{kvp.Value}");
            }
        }

        /// <summary>
        /// The Dictionary resides in <seealso cref="CarsService"/> which creates
        /// a dictionary for referencing car companies, models and years.
        /// </summary>
        private static void GroupByYearPartOfDateTime()
        {

            CarsService carsService = new();

            ICollection<Car> cars = carsService.GetAllCars();

            List<CarItem> groupedCarItems = cars
                .GroupBy(car => car.ProductionDate.Year)
                .Select(@group => new CarItem
                {
                    Id    = @group.Key,
                    List  = @group.ToList(),
                    Count = @group.Count()
                })
                .OrderBy(carItem => carItem.Id)
                .ToList();

            StringBuilder builder = new();

            foreach (CarItem carItem in groupedCarItems)
            {

                builder.AppendLine($"{carItem.Id,-8}{carItem.Count}");

                var items = carItem.List.GroupBy(car => car.Make).ToList();

                foreach (var item in items.OrderBy(x => x.Key))
                {
                    foreach (var car in item.Ordering())
                    {
                        builder.AppendLine($"\t\t{car.Model,-5} {car.ProductionDate:MM/dd/yyyy}");
                    }
                }

            }

            Debug.WriteLine(builder.ToString());

        }

        [ModuleInitializer]
        public static void Init1()
        {
            Console.Title = "Working with Dictionaries";
        }

    }
}