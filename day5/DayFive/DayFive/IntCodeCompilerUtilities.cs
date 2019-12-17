using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace DayFive
{
    public static class IntCodeCompilerUtilities
    {
        private static Tuple<int, int> currentLocation;

        public static IList<IList<T>> Permutations<T>(IList<T> l) 
        {
            if (l.Count <= 1) return new List<IList<T>> { l.Select(i => i).ToList() };
            IList<IList<T>> rv = new List<IList<T>>();
            for(int i = 0; i < l.Count; ++i)
            {
                IList<T> cp = l.Select(x => x).ToList();
                T head = cp[i];
                cp.RemoveAt(i);
                foreach(var tail in Permutations(cp))
                {
                    tail.Insert(0, head);
                    rv.Add(tail);
                }
            }        
            return rv;
            
        }

        public static long DaySeven(IList<long> input)
        {
            long largest = 0;
            var perms = Permutations(new List<int> { 0, 1, 2, 3, 4 });
            foreach (var perm in perms)
            {
                long output=0;
                for (int i = 0; i < perm.Count; ++i)
                {
                    Queue<long> q = new Queue<long>();
                    q.Enqueue(perm[i]);
                    q.Enqueue(output);
                    var nextinput = input.Select(x => x).ToList();
                    var icc = new IntCodeCompiler(nextinput, q);
                    icc.Calculate();
                    output = icc.LastOutput;
                }
                if (largest < output)
                    largest = output;

            }
            return largest;

        }

        public static long DaySevenB(IList<long> sourcecode)
        {
            long largest = 0;
            var perms = Permutations(new List<long> { 5,6,7,8,9 });
            foreach(var perm in perms)
            {
                var compilers = Enumerable.Range('A', 5).Select(c => new IntCodeCompiler(c.ToString(), sourcecode.Select(s => s).ToList(), false)).ToList();
                long score = FeedbackLoop(compilers, perm);
                if (score > largest)
                    largest = score;
            }
            return largest;
        }

        public static long FeedbackLoop(IList<IntCodeCompiler> compilers, IList<long> perm)
        {
            int i;
            for(i = 0; i < compilers.Count; ++i)
            {
                compilers[i].Calculate();
                if (compilers[i].State == CompilerState.PausedWaitingForInput)
                {
                    compilers[i].ProvideInput(perm[i]);
                    compilers[i].Calculate();
                }
            }
            i = 0;
            bool firstIteration = true;
            while (true)
            {
                if (compilers[i].State == CompilerState.PausedWaitingForInput)
                {
                    if (firstIteration && i == 0)
                    {
                        compilers[i].ProvideInput(0);
                        firstIteration = false;
                    }
                    else
                    {
                        compilers[i].ProvideInput(compilers[(i + compilers.Count - 1) % compilers.Count].LastOutput);
                    }
                    compilers[i].Calculate();
                    if (compilers[i].State == CompilerState.Halted)
                    {
                        if (i == compilers.Count - 1)
                            return compilers[i].LastOutput;
                    }
                }
                i = (i + 1) % compilers.Count;                
            }
        }

        public static int DayElevenA(IntCodeCompiler d11)
        {
            var panels = PaintMyWagon(d11, 0);
            return panels.Where(kvp => kvp.Value > 0).Count();
        }

        public static void DayElevenB(IntCodeCompiler d11)
        {
            var panels = PaintMyWagon(d11, 1);
            int minX = panels.Select(kvp => kvp.Key.Item1).Min();
            int minY = panels.Select(kvp => kvp.Key.Item2).Min();
            int maxX = panels.Select(kvp => kvp.Key.Item1).Max();
            int maxY = panels.Select(kvp => kvp.Key.Item2).Max();


            for (int y = maxY; y >= minY; --y)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = minX; x <= maxX; ++x)
                {
                    Tuple<int, int> location = new Tuple<int, int>(x, y);
                    sb.Append(panels.ContainsKey(location) && panels[location] % 2 == 1 ? '#' : '.');
                }
                Console.WriteLine(sb.ToString());
            }
        }

        static IDictionary<Tuple<int, int>, int> PaintMyWagon(IntCodeCompiler d11, int initialPanel)
        {

            IDictionary<Tuple<int, int>, int> panels = new Dictionary<Tuple<int, int>, int>();
            panels.Add(new Tuple<int, int>(0, 0), initialPanel);
            int direction = 0;
            Tuple<int, int> currentLocation = new Tuple<int, int>(0, 0);
            d11.Calculate();
            while (d11.State != CompilerState.Halted)
            {
                if (d11.State == CompilerState.PausedWaitingForInput)
                {
                    if (!panels.ContainsKey(currentLocation))
                        panels.Add(currentLocation, 0);
                    d11.ProvideInput(panels[currentLocation] % 2);
                }
                d11.Calculate();
                if (d11.OutputQueue.Count >= 2)
                {
                    long colour = d11.OutputQueue.Dequeue();
                    long turn = d11.OutputQueue.Dequeue();
                    if (panels[currentLocation] % 2 != colour)
                        panels[currentLocation]++;
                    direction = (direction + (turn == 0 ? 270 : 90)) % 360;
                    switch (direction)
                    {
                        case (0):
                            currentLocation = new Tuple<int, int>(currentLocation.Item1, currentLocation.Item2 + 1);
                            break;
                        case (90):
                            currentLocation = new Tuple<int, int>(currentLocation.Item1 + 1, currentLocation.Item2);
                            break;
                        case (180):
                            currentLocation = new Tuple<int, int>(currentLocation.Item1, currentLocation.Item2 - 1);
                            break;
                        case (270):
                            currentLocation = new Tuple<int, int>(currentLocation.Item1 - 1, currentLocation.Item2);
                            break;
                    }
                }
            }
            return panels;
        }
    }
}
