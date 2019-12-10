using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayTwo.Tests
{
    [TestClass]
    public class OpcodeTests
    {
        [TestMethod]
        public void TestGiven()
        {
            Assert.AreEqual(2, DayTwo.Program.Calculate(new List<int> { 1, 0, 0, 0, 99 }));
            Assert.AreEqual(2, DayTwo.Program.Calculate(new List<int> { 2, 3, 0, 3, 99 }));
            Assert.AreEqual(2, DayTwo.Program.Calculate(new List<int> { 2, 4, 4, 5, 99, 0 }));
            Assert.AreEqual(30, DayTwo.Program.Calculate(new List<int> { 1, 1, 1, 4, 99, 5, 6, 0, 99 }));

        }
    }
}
