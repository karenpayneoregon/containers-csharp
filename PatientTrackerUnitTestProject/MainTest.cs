using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using CommonLibrary.Classes;
using CommonLibrary.LanguageExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientTrackerUnitTestProject.Base;
using ThirdPartyLibrary.Classes;
using ThirdPartyLibrary.Models;
using static System.DateTime;

namespace PatientTrackerUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.ReadOnly)]
        public void DepartmentCountTest()
        {
            IReadOnlyList<Department> departments = References.Departments();
            Assert.AreEqual(departments.Count,20);
            
            IOrderedEnumerable<Department> ordered = References.Departments().OrderBy(department => department.Name);

            foreach (var department in ordered)
            {
                Debug.WriteLine(department);
            }

        }

        [TestMethod]
        [TestTraits(Trait.Regular)]
        public void DepartmentEditableListTest()
        {
            List<Departments> departments = References.DepartmentEditableList;

            Assert.AreEqual(departments[5].Name, "Breast screening");

            departments[5].Name = "Breast screening level 1";

            Assert.AreEqual(departments[5].Name, "Breast screening level 1");

        }


        [TestMethod]
        [TestTraits(Trait.Immutable)]
        public void PossibleTimeZonesTest()
        {
            var dstDate = new DateTime(Now.Year, Now.Month, Now.Day, 0, 0, 0);
            DateTimeOffset thisTime = new DateTimeOffset(dstDate, new TimeSpan(-7, 0, 0));

            ImmutableList<string> results = thisTime.PossibleTimeZones();

            foreach (var result in results)
            {
                Debug.WriteLine(result);
            }

            //results[0] = "";


        }

        [TestMethod]
        [TestTraits(Trait.ReadOnly)]
        public void InternetLocalTest()
        {
            DateTimeOffset? current = InternetHelpers.LocalTime();

            if (current.HasValue)
            {
                Debug.WriteLine(DateTimeHelpers.ShowPossibleTimeZones(current.Value));

                var result = $"{DateTimeHelpers.ReturnTimeOnServer($"{Now.Month}/{Now.Date}/{Now.Year} 2:58:43 -08:00")}";

                //Debug.WriteLine($"ReturnTimeOnServer: {result}");

                ImmutableList<string> zones = current.Value.PossibleTimeZones();
                //zones[0] = "";
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }


    }
}
