using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Monitor.Tests
{
    [TestClass]
    public class MonitorTests
    {
        [TestMethod]
        public void TestArgumentsAreValid()
        {
            string[] args = new string[3] { "Notepad", "1", "1" };
            var validator = new ArgumentsValidator();
            bool result = validator.ValidateArguments(args);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestArgumentsAreNotValid()
        {
            string[] args = new string[2] { "Notepad", "1" };
            var validator = new ArgumentsValidator();
            bool result = validator.ValidateArguments(args);

            Assert.IsFalse(result);
        }
    }
}
