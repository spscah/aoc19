using DaySix.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DaySix.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> orbits = System.IO.File.ReadAllLines(@"orbits.txt").Select(s => s).ToList();
            OrbitCounter oc = new OrbitCounter(orbits);
            Console.WriteLine(oc.TotalOrbits);
            Console.WriteLine(oc.OrbitalJumps("YOU", "SAN"));
            Console.ReadKey();
        }
    }
}
