using System;
using System.Collections.Generic;
using System.Diagnostics;
using StructConsoleApp.Containers;

namespace StructConsoleApp
{
    /// <summary>
    /// structs are useful for small data structures
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeData integer = new (21);
            Results(integer);
        }

        private static void Results(EmployeeData integer)
        {
            //integer.Id = 9;
        }

        private static void Sample1()
        {
            ReferrerInfo referrerInfo1;
            referrerInfo1.Language = 'E';
            referrerInfo1.ConfirmAnswer = "Please confirm your answer:";
            referrerInfo1.ConfirmReturnToMainMenu = "Are you sure you want to return to the main menu and cancel this submission?";

            Debug.WriteLine(referrerInfo1.ConfirmAnswer);

            ReferrerInfo referrerInfo2 = new ReferrerInfo
            {
                Language = 'E',
                ConfirmAnswer = "Please confirm your answer:",
                ConfirmReturnToMainMenu = "Are you sure you want to return to the main menu and cancel this submission?",
                Item = new Item() {Value = "Hello"}
            };

            Debug.WriteLine(referrerInfo2.ConfirmAnswer);
            Debug.WriteLine(referrerInfo2.Item.Value);
            Debug.WriteLine(referrerInfo2);

        }

        private static void DefaultValueDemo()
        {
            rcEnglish rc = new rcEnglish();
            Debug.WriteLine(rc.Continue);
        }

        private static void StructureOrClass()
        {
            WeatherStructure weatherStructure = new()
            {
                RecordedAt = DateTime.Now,
                TemperatureInCelsius = 20,
                PressureInMillibars = 998.0m
            };

            // not possible
            // weather.PressureInMillibars = 1;

            List<WeatherStructure> weatherStructures = new()
            {
                weatherStructure
            };


            WeatherClass weatherClass = new()
            {
                RecordedAt = DateTime.Now,
                TemperatureInCelsius = 20,
                PressureInMillibars = 998.0m
            };


            List<WeatherClass> weatherClasses = new()
            {
                weatherClass
            };
        }
    }
}
