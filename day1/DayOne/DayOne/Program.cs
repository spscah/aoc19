using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> items = System.IO.File.ReadAllLines(@"modules.txt").Select(l => Convert.ToInt32(l)).ToList();
            // items = new List<int> { 100756 };
            int modulefuel = SumFuelRequirements(items, false);
            Console.WriteLine("module fuel: {0}", modulefuel);
            modulefuel = SumFuelRequirements(items, true);
            Console.WriteLine("total: {0} ", modulefuel);
            Console.ReadKey();
        }

        static int FuelRequirement(int mass)
        {
            double dividedbythree = (double)mass / 3;
            double floored = Math.Floor(dividedbythree);
            return floored >= 2 ? (int)floored - 2 : 0;

        }
        static int SumFuelRequirements(IList<int> list, bool includeFuel)
        {
            int total = 0;
            foreach(int mass in list)
            {
                int fuel = FuelRequirement(mass);
                total += fuel;
                if (includeFuel)
                    total += FuelFuelRequirement(fuel);
            }
            return total;
        }

        static int FuelFuelRequirement(int fuelmass)
        {
            if (fuelmass <= 0)
                return 0;
            int requirement = FuelRequirement(fuelmass);
            
            return requirement + FuelFuelRequirement(requirement);
        }
    }
}
