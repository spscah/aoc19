using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayFive;

namespace AirConditioner.Tests
{
    [TestClass]
    public class IntCodeCompilerTests
    {

        [TestMethod]
        [DataRow(8, 1)]
        [DataRow(9, 0)]
        [DataRow(7, 0)]
        public void TestGiven1(int i, int e)
        {
            IList<int> input = new List<int> { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }
        [TestMethod]
        [DataRow(8, 0)]
        [DataRow(9, 0)]
        [DataRow(7, 1)]
        public void TestGiven2(int i, int e)
        {
            IList<int> input = new List<int> { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }

        [TestMethod]
        [DataRow(8, 1)]
        [DataRow(9, 0)]
        [DataRow(7, 0)]
        public void TestGiven3(int i, int e)
        {
            IList<int> input = new List<int> { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }

        [TestMethod]
        [DataRow(8, 0)]
        [DataRow(9, 0)]
        [DataRow(7, 1)]
        public void TestGiven4(int i, int e)
        {
            IList<int> input = new List<int> { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        public void TestGiven5a(int i, int e)
        {
            IList<int> input = new List<int> { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        public void TestGiven5b(int i, int e)
        {
            IList<int> input = new List<int> { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }
        [TestMethod]
        [DataRow(7, 999)]
        [DataRow(8, 1000)]
        [DataRow(9, 1001)]
        public void TestGiven6(int i, int e)
        {
            IList<int> input = new List<int> { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };
            var inputs = new Queue<int>();
            inputs.Enqueue(i);
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
            Assert.AreEqual(e, icc.LastOutput);
        }
    }
}
