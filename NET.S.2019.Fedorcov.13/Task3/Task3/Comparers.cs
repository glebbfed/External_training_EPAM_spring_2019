using System.Collections.Generic;


namespace Task3
{
    public class IntComparer: IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class StrComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return 1;
            }
            else if (a.Length < b.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if (a.LengthFromCenter() > b.LengthFromCenter())
            {
                return 1;
            }
            else if (a.LengthFromCenter() < b.LengthFromCenter())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
