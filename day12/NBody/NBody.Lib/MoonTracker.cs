using System;
using System.Collections.Generic;
using System.Linq;

namespace NBody.Lib
{
    public class MoonTracker
    {
        IList<Moon> _moons;

        int _timer;
        public IEnumerable<Moon> Moons {  get { return _moons.ToList().AsReadOnly(); } }
        public int CurrentTime {  get { return _timer; } }

        public int TotalEnergy
        {
            get
            {
                return _moons.Select(m => m.Kinetic * m.Potential).Sum();
            }
        }

        public MoonTracker(IList<Moon> moons)
        {
            _moons = moons.Select(m => m).OrderBy(m => m).ToList();
            _timer = 0;
            
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

        public long FirstRepeat
        {
            get
            {
                long x = FirstRepeatDim(_moons.Select(m => m.X).ToList());
                long y = FirstRepeatDim(_moons.Select(m => m.Y).ToList());
                long z = FirstRepeatDim(_moons.Select(m => m.Z).ToList());
                return LowestCommonMultiple(LowestCommonMultiple(x, y), z);
            }
        }

        long FirstRepeatDim(IList<int> positions)
        {
            IList<int> velocities = Enumerable.Range(0, positions.Count).Select(i => 0).ToList();
            SortedSet<string> previousStates = new SortedSet<string> { Stamp(positions, velocities) };
            long counter = 0;
            while (true)
            {
                ++counter;
                IList<int> updates = Enumerable.Range(0, positions.Count).Select(i => 0).ToList();
                for(int a = 0; a < positions.Count-1; ++a)
                {
                    for (int b = a+1; b < positions.Count; ++b)
                    {
                        if (positions[a] != positions[b])
                        {
                            int d = positions[a] < positions[b] ? 1 : -1;
                            updates[a] += d;
                            updates[b] -= d;
                        }
                    }
                }
                for (int a = 0; a < positions.Count; ++a)
                {
                    velocities[a] += updates[a];
                    positions[a] += velocities[a];
                }
                string st = Stamp(positions, velocities);
                if (previousStates.Contains(st))
                    return counter;
                previousStates.Add(st);
            }
        }

        string Stamp(IList<int> positions, IList<int> velocities)
        {
            return string.Format("{0}/{1}", string.Join(":", positions), string.Join(":", velocities));
        }

        public void TimeStep()
        {
            foreach (Moon m in _moons)
                m.ResetGravity();

            for (int a = 0; a < _moons.Count - 1; ++a)
            {
                for (int b = a + 1; b < _moons.Count; ++b)
                {
                    int x = 0, y = 0, z = 0;
                    Moon ma = _moons[a];
                    Moon mb = _moons[b];
                    if (ma.X != mb.X)
                        x += ma.X > mb.X ? -1 : 1;
                    if (ma.Y != mb.Y)
                        y += ma.Y > mb.Y ? -1 : 1;
                    if (ma.Z != mb.Z)
                        z += ma.Z > mb.Z ? -1 : 1;
                    ma.CacheGravity(x, y, z);
                    mb.CacheGravity(-x, -y, -z);
                }
            }
            foreach (Moon m in _moons)
            {
                m.UpdateVelocity();
                m.UpdatePosition();
            }
            ++_timer;
        }
    }

    public class Moon : IComparable<Moon>
    {
        Tuple<int, int, int> _position;
        Tuple<int, int, int> _velocity;
        string _name;
        readonly IList<int> _gravityCache;

        public int X => _position.Item1;
        public int Y => _position.Item2;
        public int Z => _position.Item3;

        public Tuple<int, int, int> Velocity => _velocity;

        public int Potential { get { return Math.Abs(_position.Item1) + Math.Abs(_position.Item2) + Math.Abs(_position.Item3); } }
        public int Kinetic { get { return Math.Abs(_velocity.Item1) + Math.Abs(_velocity.Item2) + Math.Abs(_velocity.Item3); } }
        public Moon(string n, Tuple<int, int, int> pos, Tuple<int, int, int> vel = null)
        {
            _name = n;
            _position = pos;
            _velocity = vel == null ? new Tuple<int, int, int>(0, 0, 0) : vel;
            _gravityCache = new List<int> { 0, 0, 0 };
        }

        public void ResetGravity()
        {
            _gravityCache[0] = 0;
            _gravityCache[1] = 0;
            _gravityCache[2] = 0;
        }

        public int CompareTo(Moon other)
        {
            return _name.CompareTo(other._name);
        }

        public void CacheGravity(int x, int y, int z)
        {
            _gravityCache[0] += x;
            _gravityCache[1] += y;
            _gravityCache[2] += z;
        }

        public void UpdateVelocity()
        {
            _velocity = new Tuple<int, int, int>(_velocity.Item1 + _gravityCache[0], _velocity.Item2 + _gravityCache[1], _velocity.Item3 + _gravityCache[2]);
        }

        public void UpdatePosition()
        {
            _position = new Tuple<int, int, int>(_position.Item1 + _velocity.Item1, _position.Item2 + _velocity.Item2, _position.Item3 + _velocity.Item3);
        }


        public override string ToString()
        {
            return string.Format("pos=<x={0}, y={1}, z={2}>, vel=<x={3}, y={4}, z={5}>", _position.Item1, _position.Item2, _position.Item3, _velocity.Item1, _velocity.Item2, _velocity.Item3);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + _position.GetHashCode();
                hash = hash * 23 + _velocity.GetHashCode();
                return hash;
            }
        }

    }
}
