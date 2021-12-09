using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using ClassWorkConsoleApp.Interfaces;
using CommonLibrary.Classes;

namespace ClassWorkConsoleApp.Classes
{
    public class ArrayCode : IBaseMethods
    {
        public void Basics()
        {
            string[] hours = Hours.Range();
            List<HourItem> hourItemList = Hours.HourItems(hours);

            foreach (var item in hourItemList)
            {
                Debug.WriteLine($"{item.TimeSpan}, {item}");
            }
        }
    }

  
}
