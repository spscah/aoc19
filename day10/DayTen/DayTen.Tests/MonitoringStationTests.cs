using System;
using DayTen.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayTen.Tests
{
    [TestClass]
    public class MonitoringStationTests
    {
        [TestMethod]
        public void TestGiven1()
        {
            var ms = new MonitoringStation(".#..#.....#####....#...##");
            Assert.AreEqual(8, ms.MaxVisible);
        }

        [TestMethod]
        public void TestGiven2()
        {
            var ms = new MonitoringStation("......#.#.#..#.#......#######..#.#.###...#..#.......#....#.##..#....#..##.#..#####...#..#..#....####");
            Assert.AreEqual(33, ms.MaxVisible);
        }

        [TestMethod]
        public void TestGiven3()
        {
            var ms = new MonitoringStation("#.#...#.#..###....#..#....#...##.#.#.#.#....#.#.#..##..###.#..#...##....##....##......#....####.###.");
            Assert.AreEqual(35, ms.MaxVisible);
        }

        [TestMethod]
        public void TestGiven4()
        {
            var ms = new MonitoringStation(".#..#..#######.###.#....###.#...###.##.###.##.#.#.....###..#..#.#..#.##..#.#.###.##...##.#.....#.#..");
            Assert.AreEqual(41, ms.MaxVisible);
        }

        [TestMethod]
        public void TestGiven5()
        {
            var ms = new MonitoringStation(".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##");
            Assert.AreEqual(210, ms.MaxVisible);
        }

        [TestMethod]
        public void TestStraightLine()
        {
            var ms = new MonitoringStation("#....#....#....#");
            Assert.AreEqual(2, ms.MaxVisible);
        }
        [TestMethod]
        public void TestNegativeStraightLine()
        {
            var ms = new MonitoringStation("...#..#..#..#...");
            Assert.AreEqual(2, ms.MaxVisible);
        }
        [TestMethod]
        public void TestVerticalLine()
        { 
            var ms = new MonitoringStation("#....#....#....#....#....");
            Assert.AreEqual(2, ms.MaxVisible);
        }

        [TestMethod]
        public void TestHorizontalLine()
        {
            var ms = new MonitoringStation("####............");
            Assert.AreEqual(2, ms.MaxVisible);
        }

        [TestMethod]
        public void TestStraightLine2()
        {
            var ms = new MonitoringStation("####...........#");
            Assert.AreEqual(4, ms.MaxVisible);
        }
    }
}
