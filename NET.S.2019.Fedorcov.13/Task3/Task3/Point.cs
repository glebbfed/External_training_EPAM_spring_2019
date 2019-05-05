using System;

namespace Task3
{
    public class Point
    {
        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType() || obj == null)
            {
                return false;
            }

            Point point = (Point)obj;

            return point.X == X && point.Y == Y;
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double LengthFromCenter()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }
}
