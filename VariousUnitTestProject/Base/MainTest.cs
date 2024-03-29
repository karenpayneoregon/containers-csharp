﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ReSharper disable once CheckNamespace - do not change
namespace VariousUnitTestProject
{
    public partial class MainTest
    {

        /// <summary>
        /// Perform initialization before each test runs
        /// </summary>
        /// <returns>Nothing we care about</returns>
        /// <remarks>
        /// For synchronous preparation
        /// * Remove the async modifier
        /// * Remove the line with await Task.Delay(0);
        /// </remarks>
        [TestInitialize]
        public void Init()
        {
            if (TestContext.TestName == nameof(UnexpectedWhenNotProperlyTesting))
            {

            }
        }

        [TestCleanup]
        public void TestCleanup()
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
