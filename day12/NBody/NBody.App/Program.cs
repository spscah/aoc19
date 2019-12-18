using NBody.Lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace NBody.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Moon a = new Moon("A", new Tuple<int, int, int>(-7, -8, 9));
            Moon b = new Moon("B", new Tuple<int, int, int>(-12, -3, -4));
            Moon c = new Moon("C", new Tuple<int, int, int>(6, -17, -9));
            Moon d = new Moon("D", new Tuple<int, int, int>(4, -10, -6));

            MoonTracker mt = new MoonTracker(new List<Moon> { a, b, c, d });

            Console.WriteLine(mt.FirstRepeat);
            Console.ReadKey();

        }
    }
}
