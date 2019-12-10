using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayThree;

namespace CrossedWires.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void TestGivenA(string w1, string w2, int expected)
        {
            DayThree.CrossedWires cw = new DayThree.CrossedWires(w1,w2, false);
            Assert.AreEqual(expected, cw.Closest);
        }

        [TestMethod]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51","U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void TestGivenB(string w1, string w2, int expected)
        {
            DayThree.CrossedWires cw = new DayThree.CrossedWires(w1, w2, true);
            Assert.AreEqual(expected, cw.StepCount);
        }
    }
}
