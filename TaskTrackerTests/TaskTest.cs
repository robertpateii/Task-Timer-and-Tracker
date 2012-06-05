using TaskTracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TaskTrackerTests
{
    
    
    /// <summary>
    ///This is a test class for TaskTest and is intended
    ///to contain all TaskTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TaskTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Task Constructor
        ///</summary>
        [TestMethod()]
        public void TaskConstructorTest()
        {
            Task target = new Task();
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(target,typeof(Object));
            Assert.AreEqual(target.Name, "");
            Assert.AreEqual(target.Time, TimeSpan.Zero);
            Assert.IsInstanceOfType(target.TimeString, typeof(String));
        }

        /// <summary>
        ///A test for IsChecked
        ///</summary>
        [TestMethod()]
        public void IsCheckedTest()
        {
            Task target = new Task("", TimeSpan.Zero, true);
            Assert.IsTrue(target.IsChecked);
            bool expected = false;
            bool actual;
            target.IsChecked = expected;
            actual = target.IsChecked;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Task Constructor
        ///</summary>
        [TestMethod()]
        public void TaskConstructorTest1()
        {
            string name = "Test Constructor";
            TimeSpan time = new TimeSpan(1, 0, 0);
            bool selected = false;
            Task target = new Task(name, time, selected);
            Assert.AreEqual(target.Name, name);
            Assert.AreEqual(target.Time, time);
            Assert.AreEqual(target.IsChecked, selected);
            Assert.AreEqual(target.TimeString, time.Hours.ToString() + ":" + time.Minutes.ToString());
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            Task target = new Task();
            string expected = "Test String";
            string actual;
            target.Name = expected;
            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Time
        /// Verifies that what you get out is the same as what you set.
        ///</summary>
        [TestMethod()]
        public void TimeTest()
        {
            Task target = new Task();
            TimeSpan expected = new TimeSpan(1,1,1);
            TimeSpan actual;
            target.Time = expected;
            actual = target.Time;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TimeString
        ///</summary>
        [TestMethod()]
        public void TimeStringTest()
        {
            Task target = new Task();
            target.Time = new TimeSpan(3, 2, 1);
            string expected = "3:2";
            string actual = target.TimeString;
            Assert.AreEqual(expected, actual);
        }
    }
}
