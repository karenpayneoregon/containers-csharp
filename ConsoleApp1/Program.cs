using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleApp1.Classes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationMobileClaimsExample();
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
