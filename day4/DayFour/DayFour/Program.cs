using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc = new SecureContainer(307237, 769058);
            Console.WriteLine(sc.HowMany1);
            Console.WriteLine(sc.HowMany2);
            Console.ReadKey();            
        }
    }

    class SecureContainer
    {
        readonly int _from;
        readonly int _to;
        readonly int _howMany1;
        readonly int _howMany2;

        public int HowMany1 => _howMany1;
        public int HowMany2 => _howMany2;

        public SecureContainer(int f, int t)
        {
            _from = f;
            _to = t;

            _howMany1 = Enumerable.Range(f, (t - f) + 1).Where(i => Adjacent(i) && Increasing(i)).Count();
            _howMany2 = Enumerable.Range(f, (t - f) + 1).Where(i => Adjacent(i) && Increasing(i) && DoubleNotTriple(i)).Count();

        }

        bool DoubleNotTriple(int i)
        {
            if (!Adjacent(i))
                return false;
            string s = i.ToString();
            if ((s[0] == s[1] && s[1] != s[2]) || (s[4] == s[5] && s[3] != s[4]))
                return true;
            
            for (int c = 0; c < s.Length - 3; ++c)
                if (s[c] != s[c + 1] && s[c+1] == s[c+2] && s[c+2] != s[c+3])
                    return true;
            return false;
        }


        bool Adjacent(int i)
        {
            string s = i.ToString();
            for (int c = 0; c < s.Length - 1; ++c)
                if (s[c] == s[c + 1])
                    return true;
            return false;
        }

        bool Increasing(int i)
        {
            string s = i.ToString();
            for (int c = 0; c < s.Length - 1; ++c)
                if (s[c] > s[c + 1])
                    return false;
            return true;

        }

    }
}
