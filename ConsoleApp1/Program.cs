using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConsoleApp1.Classes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
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
        /// Demonstrates disallowing global settings modifications
        /// </summary>
        private static void ApplicationMobileClaimsExample()
        {

            Debug.WriteLine(ApplicationSettings.Instance.Environment);
            Debug.WriteLine(ApplicationSettings.Instance.QryCacheShort);
            Debug.WriteLine(ApplicationSettings.Instance.Configuration.BaseServerAddress);

        }

        private static void ClampDecimal()
        {
            decimal min = 10;
            decimal max = 20;

            Debug.WriteLine(Math.Clamp(12, min, max));
        }

        private static void ClampInt()
        {
            int min = 10;
            int max = 20;

            Debug.WriteLine(Math.Clamp(12, min, max));
        }
    }

}
