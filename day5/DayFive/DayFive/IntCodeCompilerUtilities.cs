using System.Collections.Generic;
using System.Linq;
using System;

namespace DayFive
{
    public static class IntCodeCompilerUtilities
    {
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
    }
}
