using System;

namespace PiApproximator
{
    public class Point
    {
        double x = 0, y = 0;

        public static Point NewPoint()
        {
            Random r = new Random();
            return new Point { x = r.NextDouble(), y = r.NextDouble() };
        }

        public override bool Equals(Object otherPoint)
        {
            Point point = otherPoint as Point;
            return this.x == point.x && this.y == point.x;
        }

        public static bool operator ==(Point otherPoint, Point newPoint)
        {
            return otherPoint.x == newPoint.x && otherPoint.y == newPoint.x;
        }

        public static bool operator !=(Point otherPoint, Point newPoint)
        {
            return (newPoint == otherPoint) == false;
        }

        public bool InsideRadius()
        {
            return (Math.Pow(x, 2) + Math.Pow(y, 2)) <= 1;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}