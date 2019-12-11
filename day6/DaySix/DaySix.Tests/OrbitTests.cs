using System;
using System.Collections.Generic;
using DaySix.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaySix.Tests
{
    [TestClass]
    public class OrbitTests
    {
        [TestMethod]
        public void TestGiven()
        {
            OrbitCounter oc = new OrbitCounter(new List<string> { "COM)B","B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L" });
            Assert.AreEqual(42, oc.TotalOrbits);
        }
        [TestMethod]
        public void TestGiven2()
        {
            OrbitCounter oc = new OrbitCounter(new List<string> { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN" });
            Assert.AreEqual(4, oc.OrbitalJumps("YOU","SAN"));
        }
    }
}
