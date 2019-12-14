using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DayTen.Lib
{
    public class MonitoringStation
    {
        readonly string _map;
        readonly int _sideLength;
        readonly IList<Point> _points;
        public MonitoringStation(string map)
        {
            _map = map;
            _sideLength = (int)Math.Sqrt(map.Length);
            _points = Enumerable.Range(0, map.Length).Where(i => map[i] == '#').Select(i => new Point(i, _sideLength)).ToList();
        }

        public int MaxVisible
        {
            get
            {
                // var results = Enumerable.Range(0, _map.Length).Select(i => Visible(i)).ToList();
                var results = _points.Select(i => Visible(i)).ToList();
                var m = results.Max();
                var ind = results.IndexOf(m);
                return results.Max();
            }
        }

        int Visible(Point p)
        {
            IList<Point> others = _points.Where(i => !i.Equals(p)).ToList();
            foreach(Point blocker in _points.Where(i => !i.Equals(p)))
            {
                var potentiallyblocked = others.Where(i => !i.Equals(blocker)).Where(i => blocker.OnTheLineBetween(p, i)).Select(i => i).ToList();
                foreach (Point doomed in potentiallyblocked)
                    others.Remove(doomed);
                 
            }
            return others.Count;
        }
    }

    public class Point : IEquatable<Point>
    {
        public int X;
        public int Y;

        public Point(int i, int sl)
        {
            X = i % sl;
            Y = i / sl;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        bool CouldBe(Point oneCorner, Point otherCorner)
        {
            int topLeftX, bottomRightX;
            if (oneCorner.X <= otherCorner.X)
            {
                topLeftX = oneCorner.X;
                bottomRightX = otherCorner.X; 
            } else
            {
                topLeftX = otherCorner.X;
                bottomRightX = oneCorner.X;
            }
            int topLeftY, bottomRightY;
            if (oneCorner.Y >= otherCorner.Y)
            {
                topLeftY = oneCorner.Y;
                bottomRightY = otherCorner.Y;
            }
            else
            {
                topLeftY = otherCorner.Y;
                bottomRightY = oneCorner.Y;
            }



            return (X >= topLeftX && X <= bottomRightX && Y <= topLeftY && Y >= bottomRightY);
        }

        public bool OnTheLineBetween(Point a, Point b)
        {
            if (!CouldBe(a, b))
                return false;
            if (a.Y == b.Y && a.Y == Y)
                return a.X < X && X < b.X || a.X > X && X > b.X;
            if (a.X == b.X && a.X == X)
                return a.Y < Y && Y < b.Y || a.Y > Y && Y > b.Y;
            double g1 = a.Gradient(this);
            double g2 = Gradient(b);
            bool rv = Math.Abs(g1 - g2) < double.Epsilon * 100;
            return rv;
        }

        double Gradient(Point p)
        {
            return (double)(p.Y - Y) / (double)(p.X - X);
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
