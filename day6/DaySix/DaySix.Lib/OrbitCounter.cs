using System.Collections.Generic;
using System.Linq;

namespace DaySix.Lib
{
    public class OrbitCounter
    {
        readonly IList<string> _orbits;
        int _counter;

        public int TotalOrbits => _counter;
        public OrbitCounter(IList<string> orbits)
        {
            _counter = 0;
            _orbits = orbits;
            Calculate();
        }

        void Calculate()
        {
            IList<string> sources = _orbits.Select(o => o.Split(')').ToList()[0]).Distinct().ToList();
            IDictionary<string, int> counters = sources.ToDictionary(o => o, o => 0);
            foreach (string orbiter in _orbits.Select(o => o.Split(')').ToList()[1]).Distinct())
            {
                sources.Remove(orbiter);
                if (!counters.ContainsKey(orbiter))
                    counters.Add(orbiter, 0);
            }
            Queue<string> visit = new Queue<string>();
            foreach (string source in sources)
                visit.Enqueue(source);

            while (visit.Count > 0)
            {
                string com = visit.Dequeue();
                foreach (string detail in _orbits.Where(o => o.StartsWith(com+")")))
                {
                    IList<string> split = detail.Split(')').ToList();
                    counters[split[1]] += 1 + counters[split[0]];
                    visit.Enqueue(split[1]);
                }
            }

            _counter = counters.Select(kvp => kvp.Value).Sum();
        }

        public int OrbitalJumps(string f, string t)
        {
            IList<string> fchain = new List<string> { f };
            IList<string> tchain = new List<string> { t };
            while(true)
            {
                AddNextLink(fchain);
                AddNextLink(tchain);
                IList<string> intersection = fchain.Intersect(tchain).ToList();
                if (intersection.Count() > 0)
                {
                    return fchain.IndexOf(intersection[0]) - 2 + tchain.IndexOf(intersection[0]);
                }

            }

        }
        void AddNextLink(IList<string> chain)
        {
            string link = chain.Last();
            string res = _orbits.Where(o => o.EndsWith(")" + link)).FirstOrDefault();
            if (!string.IsNullOrEmpty(res))
                chain.Add(res.Split(')')[0]);
        }
    }
}
