using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ThirdPartyLibrary.Classes;
using ThirdPartyLibrary.Models;

namespace SortedListConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = References.VendorsUnSorted();
            SortedList sortedList = new();

            foreach (var vendor in list)
            {
                sortedList.Add(vendor.DisplayName, vendor);
            }

            // no duplicates allowed, here an exception is thrown because we
            // are attempted to add an existing key.
            try
            {
                sortedList.Add(list[0].DisplayName, list[0]);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            Debug.WriteLine("");

            // see if a key exists, if so remove the item
            var position = sortedList.IndexOfKey("Select");
            if (position > -1)
            {
                sortedList.RemoveAt(position);
                Debug.WriteLine($"Removed index {position}");
            }
            else
            {
                Debug.WriteLine("Item not located");
            }
            
            Debug.WriteLine("");

            // show data sorted by DisplayName
            foreach (DictionaryEntry dictionaryEntry in sortedList)
            {
                var vendor = (Vendor)dictionaryEntry.Value;
                Debug.WriteLine($"{vendor.Id,-3:D2}{dictionaryEntry.Key}");
            }

            Debug.WriteLine("");

            // Get all vendors
            var valueList = sortedList.GetValueList();

            foreach (Vendor vendor in valueList)
            {
                Debug.WriteLine(vendor.DisplayName);
            }


            Debug.WriteLine("");
            // set vendor to a new vendor, we can also update the current vendor
            sortedList.SetByIndex(0, new Vendor(20, "KP100", "Karen's coffee", 1));


            foreach (DictionaryEntry dictionaryEntry in sortedList)
            {
                var vendor = (Vendor)dictionaryEntry.Value;
                Debug.WriteLine($"{vendor.Id,-3:D2}{vendor.DisplayName}");
            }



        }
    }
}
