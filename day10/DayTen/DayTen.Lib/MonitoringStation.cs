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


        public int VaporiseOrder(int i)
        {
            // this is massively inefficient 
            IList<int> visibility = _points.Select(p => Visible(p).Count).ToList();
            int m = visibility.Max();
            int ind = visibility.IndexOf(m);
            Point centre = _points[ind];
            if( i > m)
            {
                // hack - huge fudge 
                throw new NotImplementedException();
            }
            IList<Point> innershell = Visible(centre);
            IDictionary<Point, double> angles = innershell.ToDictionary(p => p, p => centre.AngleToPoint(p));
            int counter = 0;
            foreach (var pair in angles.OrderBy(p => p.Value))
            {
                // work with pair.Key and pair.Value
                ++counter;
                if (counter == i)
                    return (100 * pair.Key.X) + pair.Key.Y;
            }
            return -1;
        }


        public int MaxVisible(bool returnIndex=false)
        {
            // var results = Enumerable.Range(0, _map.Length).Select(i => Visible(i)).ToList();
            var results = _points.Select(i => Visible(i).Count).ToList();
            var m = results.Max();
            var ind = results.IndexOf(m);
            return returnIndex ? ind : results.Max();
        }

        IList<Point> Visible(Point p, IList<Point> pointsToUse = null)
        {
            if (pointsToUse == null)
                pointsToUse = _points;
            IList<Point> others = pointsToUse.Where(i => !i.Equals(p)).ToList();
            foreach(Point blocker in pointsToUse.Where(i => !i.Equals(p)))
            {
                var potentiallyblocked = others.Where(i => !i.Equals(blocker)).Where(i => blocker.OnTheLineBetween(p, i)).Select(i => i).ToList();
                foreach (Point doomed in potentiallyblocked)
                    others.Remove(doomed);
                 
            }
            return others;
        }
    }

    public class Point : IEquatable<Point>
    {
        public int X;
        public int Y;

        public Point(int x, int y, bool mcguffin)
        {
            X = x; Y = y;
        }
        public Point(int i, int sl)
        {
            X = i % sl;
            Y = i / sl;
        }

        public bool Equals(Point other)
        {
            if (other == null)
                return false;
            return X == other.X && Y == other.Y;
        }
        public override bool Equals(object obj)
        {
            return obj as Point == null ? false : Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode
            unchecked // Overflow is fine, just wrap
            {
                int hash = 31;
                // Suitable nullity checks etc, of course :)
                hash = hash * 37 + X.GetHashCode();
                hash = hash * 37 + Y.GetHashCode();
                return hash;
            }
        }

        public Point ReturnNearestAndRemove(IList<Point> list)
        {
            var closest = list.Select(p => Distance(p)).Min();
            var point = list.Where(p => Math.Abs(Distance(p) - closest) < double.Epsilon).First();
            list.Remove(point);
            return point;
        }

        double Distance(Point p)
        {
            double d= Math.Sqrt(((p.X - X) * (p.X - X)) + ((p.Y - Y) * (p.Y - Y)));
            return d;
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

        internal double AngleToPoint(Point other)
        {
            if (Math.Abs(other.X - X) < double.Epsilon)
                return (other.Y > Y) ? 180 : 0;
            if (Math.Abs(other.Y - Y) < double.Epsilon)
                return (other.X > X) ? 90 : 270;

            double angle = 360 * Math.Atan(Math.Abs(other.X - X) / (double)Math.Abs(other.Y - Y)) / (2d * Math.PI);
            if(other.X > X)
            {
                if (other.Y > Y)
                    return 180 - angle;
                else
                    return 0 + angle;
            } else
            {
                if (other.Y < Y)
                    return 360 - angle;
                else
                    return 180 + angle;
            }
        }
    }
}
