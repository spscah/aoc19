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
            Assert.AreEqual(8, ms.MaxVisible());
        }

        [TestMethod]
        public void TestGiven2()
        {
            var ms = new MonitoringStation("......#.#.#..#.#......#######..#.#.###...#..#.......#....#.##..#....#..##.#..#####...#..#..#....####");
            Assert.AreEqual(33, ms.MaxVisible());
        }

        [TestMethod]
        public void TestGiven3()
        {
            var ms = new MonitoringStation("#.#...#.#..###....#..#....#...##.#.#.#.#....#.#.#..##..###.#..#...##....##....##......#....####.###.");
            Assert.AreEqual(35, ms.MaxVisible());
        }

        [TestMethod]
        public void TestGiven4()
        {
            var ms = new MonitoringStation(".#..#..#######.###.#....###.#...###.##.###.##.#.#.....###..#..#.#..#.##..#.#.###.##...##.#.....#.#..");
            Assert.AreEqual(41, ms.MaxVisible());
        }

        [TestMethod]
        public void TestGiven5()
        {
            var ms = new MonitoringStation(".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##");
            Assert.AreEqual(210, ms.MaxVisible());
        }

        [TestMethod]
        public void TestStraightLine()
        {
            var ms = new MonitoringStation("#....#....#....#");
            Assert.AreEqual(2, ms.MaxVisible());
        }
        [TestMethod]
        public void TestNegativeStraightLine()
        {
            var ms = new MonitoringStation("...#..#..#..#...");
            Assert.AreEqual(2, ms.MaxVisible());
        }
        [TestMethod]
        public void TestVerticalLine()
        { 
            var ms = new MonitoringStation("#....#....#....#....#....");
            Assert.AreEqual(2, ms.MaxVisible());
        }

        [TestMethod]
        public void TestHorizontalLine()
        {
            var ms = new MonitoringStation("####............");
            Assert.AreEqual(2, ms.MaxVisible());
        }

        [TestMethod]
        public void TestStraightLine2()
        {
            var ms = new MonitoringStation("####...........#");
            Assert.AreEqual(4, ms.MaxVisible());
        }

        [TestMethod]
        public void TestPart2a()
        {
            var ms = new MonitoringStation(".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##");
            Assert.AreEqual(1112, ms.VaporiseOrder(1));
            Assert.AreEqual(1201, ms.VaporiseOrder(2));
            Assert.AreEqual(1202, ms.VaporiseOrder(3));
            Assert.AreEqual(1208, ms.VaporiseOrder(10));
            Assert.AreEqual(1600, ms.VaporiseOrder(20));
            Assert.AreEqual(1609, ms.VaporiseOrder(50));
            Assert.AreEqual(1016, ms.VaporiseOrder(100));
        }
        [TestMethod]
        public void TestPart2b()
        {
            var ms = new MonitoringStation(".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##");
            Assert.AreEqual(906, ms.VaporiseOrder(199));
            //            Assert.AreEqual(1101, ms.VaporiseOrder(299));
        }
        [TestMethod]
        public void TestPart2c()
        {
            var ms = new MonitoringStation(".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##");
            Assert.AreEqual(802, ms.VaporiseOrder(200));
            //            Assert.AreEqual(1101, ms.VaporiseOrder(299));
        }
        [TestMethod]
        public void TestPart2d()
        {
            var ms = new MonitoringStation(".#..##.###...#########.############..##..#.######.########.#.###.#######.####.#.#####.##.#.##.###.##..#####..#.##############################.####....###.#.#.####.######################.##.###..####....######..##.###########.##.####...##..#.#####..#.######.#####...#.##########...#.##########.#######.####.#.###.###.#.##....##.##.###..#####.#.#.###########.####.#.#.#####.####.######.##.####.##.#..##");
            Assert.AreEqual(1009, ms.VaporiseOrder(201));
            //            Assert.AreEqual(1101, ms.VaporiseOrder(299));
        }

    }
}
