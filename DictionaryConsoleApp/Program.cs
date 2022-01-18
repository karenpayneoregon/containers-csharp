using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CommonLibrary.Classes;
using CommonLibrary.LanguageExtensions;
using DictionaryConsoleApp.Classes;
using Microsoft.AspNetCore.WebUtilities;
using ThirdPartyLibrary.Classes;
using ThirdPartyLibrary.Models;

namespace DictionaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Merging();
            //BasicSample2();
            //DirectoryTraverse();

            //BasicSample2();

            string resultAddress = CreateAddress(5683948823, 2022,1,10);

            Debug.WriteLine(resultAddress);

            EmployeeData employeeData = new EmployeeData()
            {
                BaseAddress = "https://US.prism.co.us/ViewFile", 
                SequenceId = 5683948823, 
                YearId = DateTime.Now.Year, 
                Rec = 1, 
                Country = 10
            };
            Debug.WriteLine(employeeData.FinalAddress());

            var PropertyNames = typeof(EmployeeData).GetProperties()
                .Select(pi => pi.Name).ToList();

            
        }

        private static void GenericAdd()
        {
            string[] someText = { "Karen", "Vince", "Lisa", "Bill" };
            
            var dict = new Dictionary<string, int>();
            
            int index = 1;

            foreach (string word in someText)
            {
                dict[word] = dict.GetOrCreate(word) + index;
                index++;
            } //https://github.com/karenpayneoregon/containers-csharp
        }

        /// <summary>
        /// Dictionary where Key is a person's name, Value is birthday
        /// Iterate the Dictionary, display person's name and age.
        /// </summary>
        private static void BasicSample1()
        {
            string name = "Jane Doe";

            Dictionary<string, DateTime> users = new ()
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
                Debug.WriteLine($"{user.Key,-18} is {user.Value.Age(DateTime.Now).YearsMonthsDays} old");
            }

            Debug.WriteLine("");

        }

        /// <summary>
        /// Various ways to initialize a dictionary
        /// </summary>
        private static void BasicSample2()
        {
            Dictionary<string, List<int>> field = new()
            {
                { "item1", new() { 1, 2, 3 } },
                { "item2", Enumerable.Range(4, 10).ToList() }
            };

            foreach (var kvp in field)
            {
                Debug.WriteLine($"{kvp.Key} Values: {string.Join(",", kvp.Value)}");
            }

            field.AddSafe("item1", new() { 1, 2, 3 });  // false
            field.AddSafe("item3", new() { 1, 2, 3, 4 });

            Debug.WriteLine("");

            Dictionary<string, XlFileFormat> fileTypesDictionary = new()
            {
                { "csv", XlFileFormat.xlCSV },
                { "html", XlFileFormat.xlHtml }
            };

            foreach (var xlFileFormat in fileTypesDictionary)
            {
                Debug.WriteLine($"{xlFileFormat.Key} = {xlFileFormat.Value}");
            }

            /*
             * Alternate init
             */
            Dictionary<string, XlFileFormat> fileTypesDictionary1 = new()
            {
                ["csv"] = XlFileFormat.xlCSV,
                ["html"] = XlFileFormat.xlHtml
            };

            Dictionary<int, string> categoryDictionary = new()
            {
                [1] = "Beverages",
                [2] = "Condiments",
                [3] = "Confections"
            };

            Debug.WriteLine("");

            /*
             * iterate dictionary via it's indexer
             */
            for (int index = 0; index < categoryDictionary.Count; index++)
            {
                Debug.WriteLine($"{categoryDictionary[index + 1]}");
            }

            Debug.WriteLine("");

            /*
             * Read categories from a file, create a list of Category
             */
            var categories = File.ReadAllText("categories.json").JSonToList<Category>();

            /*
             * Create a Dictionary to contain categories
             */
            Dictionary<string, Category> categoriesDictionary = new();

            /*
             * Add categories to the dictionary
             */
            foreach (var category in categories)
            {
                categoriesDictionary.Add(category.CategoryName, category);
            }

            Debug.WriteLine($"'Dairy Products' key exists {categoriesDictionary.ContainsKey("Dairy Products").ToYesNoString()}");

            Debug.WriteLine("");



            List<Category> categoriesFromSomePlace = File.ReadAllText("categories.json")
                .JSonToList<Category>();

            /*
             * Read from file containing same data as above and use generic extension method ToDictionary
             * to create the dictionary rather than using foreach
             */
            Dictionary<string, Category> dictFromList = categoriesFromSomePlace
                .ToDictionary(
                    cat => cat.CategoryName, 
                    cat => cat);

            /*
             * iterate key values
             */
            foreach (var category in dictFromList)
            {

                Debug.WriteLine($"{category.Key,-19}{category.Value.CategoryID}");
            }
            
        }

        private static readonly List<string> folderList = new ();
        private static Dictionary<int, string> folderDictionary = new();
        /// <summary>
        /// This code sample traverses a directory backwards storing paths in a list
        /// followed by reversing the list so the root folder is first then adds the
        /// list to a Dictionary where the key is the index of the folder and the
        /// folder name.
        /// </summary>
        /// <remarks>
        /// The developer running this code may not have permissions to see the base folder
        /// and if so change the path to one which you have permissions.
        ///
        /// For out in the wild it would be prudent to use a try-catch.
        /// 
        /// </remarks>
        private static void DirectoryTraverse()
        {
            string path = @"\\devweb07\HTTP\headfoot\bootstrapIcons\1.2.0\font\fonts";
            
            if (Directory.Exists(path))
            {
                DirectoryHelper.TraverseFolder += DirectoryHelperOnTraverseFolder;
                DirectoryHelper.TraversePath(path);
                DirectoryHelper.TraverseFolder -= DirectoryHelperOnTraverseFolder;

                ImmutableDictionary<int, string> dictImmutableDictionary = GetImmutable();
                foreach (var kvp in dictImmutableDictionary)
                {
                    Debug.WriteLine($"{kvp.Key,-3}{kvp.Value}");

                }
                
            }
            else
            {
                Debug.WriteLine($"Directory not found: {path}");
            }

        }
        private static void DirectoryHelperOnTraverseFolder(string sender)
        {
            if (sender == DirectoryHelper.DoneMessage)
            {
                /*
                 * Current list is deep to shallow, we want to reverse the order
                 */
                folderList.Reverse(0, folderList.Count);
                
                for (int index = 0; index < folderList.Count; index++)
                {
                    folderDictionary.Add(index, folderList[index]);
                }

            }
            else
            {
                folderList.Add(sender);
            }

        }

        /// <summary>
        /// Return an immutable dictionary from a mutable dictionary
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Built in generic method
        /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlydictionary-2?redirectedfrom=MSDN&view=net-6.0
        /// </remarks>
        public static ImmutableDictionary<int, string> GetImmutable() => 
            folderDictionary.ToImmutableDictionary();

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
                    Id = @group.Key,
                    List = @group.ToList(),
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
        /// Using a Dictionary create a url with params
        /// </summary>
        private static void AlreadyCompleted()
        {
            string language = "S";

            Dictionary<string, string> queryArguments = new()
            {
                { "transId", "64440952" }, 
                { "lang", "E" }
            };

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

            // /example/path?static-argument=foo&dynamic-argument=bar
            Debug.WriteLine(results);
            Debug.WriteLine("");

            queryArguments = new Dictionary<string, string>()
            {
                {"dog", "221" },
                {"gender", "female" },
                {"age","4,5,6" }
            };

            results = QueryHelpers.AddQueryString("/api/product/list", queryArguments);

            // /api/product/list?dog=221&gender=female&age=4,5,6
            Debug.WriteLine(results);



        }

        private static string CreateAddress(long id, int year, int rec, int country)
        {

            string address = "https://US.prism.co.us/ViewFile";
            var queryArguments = new Dictionary<string, string>()
            {
                {"SequenceId", $"{id}" },
                {"YearId", $"{year}" },
                {"Rec",$"{rec}" },
                {"country",$"{country}"}

            };

            return QueryHelpers.AddQueryString(address, queryArguments);
        }

        private static void ChangeAllValues()
        {
            var dictionary = new Dictionary<string, int>
            {
                { "something", 5 },
                { "something else", 15 }
            };

            foreach (var key in dictionary.Keys)
            {
                dictionary[key] -= 1;
            }

            dictionary = dictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value - 1);
        }

        /// <summary>
        /// Merge two dictionaries, duplicate key aware 
        /// </summary>
        private static void Merging()
        {
            Dictionary<string, List<int>> dictionary1 = new()
            {
                { "item1", new() { 1, 2, 3 } },
                { "item2", Enumerable.Range(4, 12).ToList() }
            };

            Dictionary<string, List<int>> dictionary2 = new()
            {
                { "item3", new() { 10, 20 } },
                { "item4", Enumerable.Range(45, 6).ToList() }
            };

            /*
             * rename key to ensure merging does not blow up on dup keys
             */
            dictionary2.RenameKey("item3", "item1");

            var resultsDictionary = dictionary1
                .Concat(dictionary2)
                .ToLookup(kvp => kvp.Key, kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, g => g.First());

            foreach (var item in resultsDictionary)
            {
                Debug.WriteLine(item.Key);
            }
        }

        [ModuleInitializer]
        public static void Init1()
        {
            Console.Title = "Working with Dictionaries";
        }

    }
}
