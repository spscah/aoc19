using SpaceStoichiometry.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStoichiometry.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> reactions = System.IO.File.ReadAllLines(@"reactions.txt").Select(s => s).ToList();
            var ru = new ReactionUnpacker(reactions,1000000000000);
            Console.WriteLine(ru.Unpack());
            Console.WriteLine(ru.MaximumAmountOfFuel());
            Console.WriteLine("Press any key");
            Console.ReadKey();

        }
    }
}
