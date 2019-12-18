using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBody.Lib;

namespace NBody.Tests
{
    [TestClass]
    public class MoonTrackerTests
    {
        [TestMethod]
        public void TestGivenA()
        {
            Moon a = new Moon("A", new Tuple<int, int, int>(-1, 0, 2));
            Moon b = new Moon("B", new Tuple<int, int, int>(2, -10, -7));
            Moon c = new Moon("C", new Tuple<int, int, int>(4, -8, 8));
            Moon d = new Moon("D", new Tuple<int, int, int>(3, 5, -1));
            IList<Moon> moons = new List<Moon> { a, b, c, d, };
            MoonTracker mt = new MoonTracker(moons);
            mt.TimeStep();
            Assert.AreEqual(1, mt.CurrentTime);
            Assert.AreEqual(2, a.X);
            Assert.AreEqual(3, b.X);
            Assert.AreEqual(1, c.X);
            Assert.AreEqual(2, d.X);

            mt.TimeStep();
            Assert.AreEqual(2, mt.CurrentTime);
            Assert.AreEqual(5, a.X);
            Assert.AreEqual(1, b.X);
            Assert.AreEqual(1, c.X);
            Assert.AreEqual(1, d.X);

            mt.TimeStep();
            Assert.AreEqual(3, mt.CurrentTime);
            Assert.AreEqual(-6, a.Y);
            Assert.AreEqual(0, b.Y);
            Assert.AreEqual(1, c.Y);
            Assert.AreEqual(-8, d.Y);

            mt.TimeStep();
            Assert.AreEqual(4, mt.CurrentTime);
            Assert.AreEqual(0, a.Z);
            Assert.AreEqual(7, b.Z);
            Assert.AreEqual(-6, c.Z);
            Assert.AreEqual(1, d.Z);

            mt.TimeStep();
            Assert.AreEqual(5, mt.CurrentTime);
            mt.TimeStep();
            Assert.AreEqual(6, mt.CurrentTime);
            mt.TimeStep();
            Assert.AreEqual(7, mt.CurrentTime);
            mt.TimeStep();
            Assert.AreEqual(8, mt.CurrentTime);
            mt.TimeStep();
            Assert.AreEqual(9, mt.CurrentTime);
            mt.TimeStep();
            Assert.AreEqual(10, mt.CurrentTime);

            Assert.AreEqual(2, a.X);
            Assert.AreEqual(1, b.X);
            Assert.AreEqual(3, c.X);
            Assert.AreEqual(2, d.X);

            Assert.AreEqual(6, a.Potential);
            Assert.AreEqual(9, b.Potential);
            Assert.AreEqual(10, c.Potential);
            Assert.AreEqual(6, d.Potential);
            Assert.AreEqual(6, a.Kinetic);
            Assert.AreEqual(5, b.Kinetic);
            Assert.AreEqual(8, c.Kinetic);
            Assert.AreEqual(3, d.Kinetic);

            Assert.AreEqual(179, mt.TotalEnergy);
        }

        [TestMethod]
        public void TestGivenB()
        {
            Moon a = new Moon("A", new Tuple<int, int, int>(-8, -10, 0));
            Moon b = new Moon("B", new Tuple<int, int, int>(5, 5, 10));
            Moon c = new Moon("C", new Tuple<int, int, int>(2, -7, 3));
            Moon d = new Moon("D", new Tuple<int, int, int>(9, -8, -3));
            IList<Moon> moons = new List<Moon> { a, b, c, d, };
            MoonTracker mt = new MoonTracker(moons);
            while(mt.CurrentTime < 10)
                mt.TimeStep();

            Assert.AreEqual(-9, a.X);
            Assert.AreEqual(10, b.Y);
            Assert.AreEqual(-3, c.Z);
            Assert.AreEqual(3, d.Z);

            while (mt.CurrentTime < 20)
                mt.TimeStep();

            Assert.AreEqual(-10, a.X);
            Assert.AreEqual(6, b.Z);
            Assert.AreEqual(1, c.Y);
            Assert.AreEqual(7, d.Z);

            while (mt.CurrentTime < 100)
                mt.TimeStep();

            Assert.AreEqual(100, mt.CurrentTime);
            Assert.AreEqual(1940, mt.TotalEnergy);

        }
        
        [TestMethod]
        public void FirstRepeatA()
        {
            Moon a = new Moon("A", new Tuple<int, int, int>(-1, 0, 2));
            Moon b = new Moon("B", new Tuple<int, int, int>(2, -10, -7));
            Moon c = new Moon("C", new Tuple<int, int, int>(4, -8, 8));
            Moon d = new Moon("D", new Tuple<int, int, int>(3, 5, -1));
            IList<Moon> moons = new List<Moon> { a, b, c, d, };
            MoonTracker mt = new MoonTracker(moons);
            Assert.AreEqual(2772, mt.FirstRepeat);
        }

        [TestMethod]
        public void FirstRepeatB()
        {
            Moon a = new Moon("A", new Tuple<int, int, int>(-8, -10, 0));
            Moon b = new Moon("B", new Tuple<int, int, int>(5, 5, 10));
            Moon c = new Moon("C", new Tuple<int, int, int>(2, -7, 3));
            Moon d = new Moon("D", new Tuple<int, int, int>(9, -8, -3));
            IList<Moon> moons = new List<Moon> { a, b, c, d, };
            MoonTracker mt = new MoonTracker(moons);
            Assert.AreEqual(4686774924, mt.FirstRepeat);
        }

    }

}