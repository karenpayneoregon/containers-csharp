using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExcelSpreadSheetLiteConsoleApp.Classes;

namespace ExcelSpreadSheetLiteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = "karen";

            SearchItem searchItem = new("Demo1.xlsx", "sheet1", value, StringComparison.InvariantCultureIgnoreCase);


            var (items, exception) = ExcelOperations.FindText(searchItem);
            
            if (exception is null)
            {
                if (items.Count >0)
                {
                    Debug.WriteLine($"Found {value} {items.Count} times");
                    foreach (var foundItem in items)
                    {
                        Debug.WriteLine($"{foundItem}");
                    }
                }
                else
                {
                    Debug.WriteLine($"Did not find {value}");
                }

            }
            else
            {
                Debug.WriteLine(exception.Message);
            }


            //var other = ExcelOperations.FindUsual(searchItem);
            
            
        }

        [ModuleInitializer]
        public static void Init1()
        {
            Console.Title = "Working with immutable read from Excel";
        }
    }
}
