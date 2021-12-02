using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using ListGenericConsoleApp.Classes;
using ThirdPartyLibrary.Interfaces;

namespace ListGenericConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.getrange?redirectedfrom=MSDN&view=net-6.0#System_Collections_Generic_List_1_GetRange_System_Int32_System_Int32

            //myList.RemoveRange(0, offset); // Remove items at the beginning
            //myList.RemoveRange(count, myList.Count - count); // Remove items at the end

            NoDuplicateCustomers();
        }

        /// <summary>
        /// Let's say these items came from a unknown source rather than hard-coded
        /// </summary>
        private static void NoDuplicateCustomers()
        {
            List<Customer> customers = new()
            {
                new Customer() { CustomerIdentifier = 1, CompanyName = "ABC", CountryIdentifier = 2 },
                new Customer() { CustomerIdentifier = 2, CompanyName = "ABC", CountryIdentifier = 3 },
                new Customer() { CustomerIdentifier = 1, CompanyName = "ABC", CountryIdentifier = 2 }
            };

            IEnumerable<Customer> results = customers.Distinct(new CustomerNameCountryComparer());

            foreach (var customer in results)
            {
                Debug.WriteLine($"{customer.Id, -3:D2}{customer.CountryIdentifier,-3:D2}{customer.CompanyName}");
            }
        }

        [ModuleInitializer]
        public static void Init1()
        {
            Console.Title = "Working with List";
        }
    }
}
