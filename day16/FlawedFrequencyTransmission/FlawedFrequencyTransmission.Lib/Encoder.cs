using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlawedFrequencyTransmission.Lib
{
    public class Encoder
    {
        readonly string _initialValue;
        readonly int _repetitions;
        int _iteration;
        IList<int> _cachedValue;

        public Encoder(string value, int repetition = 1)
        {
            _repetitions = repetition;
            _initialValue = value;
            _iteration = 0;
            _cachedValue = _initialValue.Select(c => c - '0').ToList();
        }

        public int SignalLength => _initialValue.Length * _repetitions;

        public int GenerateEarlySpecificIndex(int index, int iterations)
        {
            int lcm = (int)LowestCommonMultiple((index + 1) * 4, _initialValue.Length);
            int leftover = SignalLength % lcm;

            IList<int> tempValues = Enumerable.Range(0, lcm).Select(i => _initialValue[i % _initialValue.Length]).Select(c => c - '0').ToList();

            for (int i = 0; i < iterations; ++i)
            {
                int sum = 0;
                for (int j = 0; j < lcm; ++j)
                {
                    int contribution = tempValues[j] * GetPattern(index, j);

                    sum += contribution * (SignalLength / lcm);
                    sum += (j <= leftover) ? contribution : 0;
                }
                tempValues[index] = Math.Abs(sum) % 10;
            }
            return tempValues[index];
        }

        public IList<int> GenerateNextEncoding(int from = 0, int to = -1)
        {
            if (to == -1)
                to = SignalLength;
            IList<int> nextValue = Enumerable.Range(0,to-from).Select(i => 0).ToList();
            for(int i = from; i < to; ++i)
            {
                int s = 0;
                int lcm = (int)LowestCommonMultiple((i+1) * 4, _initialValue.Length);
                for(int j = 0; j < (SignalLength < lcm ? SignalLength : lcm); ++j)
                {
                    s += _cachedValue[j] * GetPattern(i, j);
                }
                int repeats = SignalLength / lcm;
                s *= repeats;
                if(SignalLength % lcm != 0)
                {
                    for(int j=repeats*lcm; j < SignalLength;++j)
                        s += _cachedValue[j] * GetPattern(i, j);

                }
                nextValue[i-from] = Math.Abs(s)%10;
            }
            ++_iteration;
            if (to == SignalLength)
            {
                _cachedValue = nextValue;
                return _cachedValue;
            }
            else 
                return nextValue;
        }


        int GetPattern(int position, int index)
        {
            int arrayLength = 4 * (position + 1);
            if ((index + 1) % arrayLength == 0)
                return 0;
            double extent = (double)((index + 1) % arrayLength)/arrayLength;
            if (extent >= 0.75)
                return -1;
            if (extent >= 0.5)
                return 0;
            if (extent >= 0.25)
                return 1;
            return 0;
        }

        public string First(int f)
        {
            return string.Join("", _cachedValue.Take(f));
        }

        public int FirstSeven()
        {
            int rv = 0;
            for(int i = 0; i < 7; ++i)
            {
                int next = GenerateEarlySpecificIndex(i, 100);
                rv *= 10;
                rv += next;
            }
            return rv;
        }

        public string RealMessage(int o=7)
        {
            
            IList<int> latest = null;
            for (int i = 0; i < 100; ++i)
                latest = GenerateNextEncoding(0,o);
            int offset = Convert.ToInt32(First(o));
            for (int i = 0; i < 100; ++i)
                latest = GenerateNextEncoding(offset, offset+8);

            return string.Join("", latest);
            
        }

        static long GreatestCommonFactor(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static long LowestCommonMultiple(long a, long b) => a / GreatestCommonFactor(a, b) * b;
    }
}
