using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ReSharper disable once CheckNamespace - do not change
namespace PatientTrackerUnitTestProject
{
    public partial class MainTest 
    {
        public static readonly ImmutableList<int> ImmutableList = new[] { 1, 2, 3 }.ToImmutableList();
        public static readonly ImmutableList<int> ImmutableList1 = Enumerable.Range(1, 5).ToImmutableList();

        [TestInitialize]
        public void Init()
        {

        }
        
        /// <summary>
        /// Perform any initialize for the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        
    }

}
