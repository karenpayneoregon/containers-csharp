using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VariousUnitTestProject.Base;
using VariousUnitTestProject.Extensions1;

namespace VariousUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        /// <summary>
        /// Version 1, coded without considering null elements
        /// Version 2, considers null elements
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.WhenNotTested)]
        [ExpectedException(typeof(NullReferenceException))]
        public void UnexpectedWhenNotProperlyTesting()
        {
            
            Debug.WriteLine($"{nameof(UnexpectedWhenNotProperlyTesting)} will throw an expected {nameof(NullReferenceException)}");

            string[] values = { "", "1", "2", null, "4", "Text" };

            // never executes
            Debug.WriteLine(values.AllInt() ? "All can be converted" : "Not all integers");
        }

        /// <summary>
        /// See <seealso cref="HasNulls"/> for real test
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void ExpectPossibleNullElements()
        {
            string[] values = { "", "1", "2", null, "4", "Text" };

            if (values.HasNullValues())
            {
                Debug.WriteLine("Null(s)");
            }
            else
            {
                Debug.WriteLine(values.AllInt() ? "All can be converted" : "Not all integers");
            }

        }


        /// <summary>
        /// Test string array for null elements, see <seealso cref="ExpectPossibleNullElements"/>
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.PlaceHolder)]
        public void HasNulls()
        {
            string[] values = { "", "1", "2", null, "4", "Text" };
            
            Assert.IsTrue(values.HasNullValues());

            values[0] = "0";
            values[3] = "3";
            
            Assert.IsFalse(values.HasNullValues());
        }


    }
}
