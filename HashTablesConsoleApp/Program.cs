﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using ThirdPartyLibrary.Classes;
using ThirdPartyLibrary.Models;

namespace HashTablesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            VendorIterateKeyValues();

        }

        /// <summary>
        /// There is no sorted <see cref="Hashtable"/> instead use a SortedDictionary
        /// </summary>
        private static void Sorted()
        {
            SortedDictionary<string, Vendor> dict = new();

            References.Vendors().ToList().ForEach(vendor => dict.Add(vendor.DisplayName, vendor));

            foreach (var vendor in dict)
            {
                Debug.WriteLine(vendor.Key);
            }
        }

        /// <summary>
        /// Shows how to iterate a HashTable, no sort
        /// </summary>
        private static void VendorIterateKeyValues()
        {
            Hashtable vendorHashtable = VendorHashtable();
            
            foreach (DictionaryEntry entry in vendorHashtable)
            {
                Debug.WriteLine($"{entry.Key}");
                var vendor = (Vendor)entry.Value;
                Debug.WriteLine($"\t{vendor.AccountNumber,-15}{vendor.Id,-3:D2}{vendor.CreditRating,-3:D2}");
            }
        }

        /// <summary>
        /// Example to check if a specific key exists
        /// </summary>
        private static void VendorContainsKey()
        {
            var vendorHashtable = VendorHashtable();

            const string vendorName = "Bergeron Off-Roads";

            if (vendorHashtable.ContainsKey(vendorName))
            {
                var vendor = (Vendor)vendorHashtable["Bergeron Off-Roads"];
                Debug.WriteLine($"ID: {vendor.Id} Credit rating: {vendor.CreditRating}");
            }
            else
            {
                Debug.WriteLine($"{vendorName} not located");
            }
        }

        /// <summary>
        /// Create a HashTable form a IReadOnlyList of <see cref="Vendor"/>
        /// </summary>
        private static Hashtable VendorHashtable()
        {
            Hashtable vendorHashtable = new();

            foreach (var vendor in References.Vendors())
            {
                vendorHashtable.Add(vendor.DisplayName, vendor);
            }

            return vendorHashtable;
        }

        private static void UpdateValue()
        {
            Hashtable Create()
            {
                Hashtable vendorHashtable = new();
                List<VendorItem> vendorItems = References.VendorItems();

                foreach (var item in vendorItems)
                {
                    vendorHashtable.Add(item.DisplayName, item);
                }

                return vendorHashtable;
            }

            var table = Create();
            var key = "Capital Road Cycles";

            if (table.ContainsKey(key))
            {
                table[key] = "Capital Road Cycles fun fun fun";
            }

            table.Remove("Select"); // no check, we know it exists

            foreach (DictionaryEntry entry in table)
            {
                Debug.WriteLine($"{entry.Key,-21} = {entry.Value}");
            }

        }
        private static void RemoveItem()
        {
            Hashtable Create()
            {
                Hashtable vendorHashtable = new();
                List<VendorItem> vendorItems = References.VendorItems();

                foreach (var item in vendorItems)
                {
                    vendorHashtable.Add(item.DisplayName,item);
                }

                return vendorHashtable;
            }

            var table = Create();
            var key = "Capital Road Cycles";

            if (table.ContainsKey(key))
            {
                table.Remove(key);
                Debug.WriteLine($"{key} has been removed");
            }
            else
            {
                Debug.WriteLine($"{key} not in table");
            }

        }

        [ModuleInitializer]
        public static void Init1()
        {
            Console.Title = "Working with HashTable";
        }

    }
}
