using DayFive;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AirConditioner.Tests
{
    [TestClass]
    public class DayNineTests
    {
        [TestMethod]
        public void TestGiven()
        {
            var icc = new IntCodeCompiler("1", new List<long> { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 }, false);
            icc.Calculate();
            Assert.AreEqual(99, icc.LastOutput);
        }

        [TestMethod]
        public void TestGiven2()
        {
            var icc = new IntCodeCompiler("1", new List<long> { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 }, false);
            icc.Calculate();
            Assert.AreEqual(16, icc.LastOutput.ToString().Length);
        }
        [TestMethod]
        public void TestGiven3()
        {
            var icc = new IntCodeCompiler("1", new List<long> { 104, 1125899906842624, 99 }, false);
            icc.Calculate();
            Assert.AreEqual(1125899906842624, icc.LastOutput);
        }
    }
}
