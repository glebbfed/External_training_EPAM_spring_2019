using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            List<int> newList = new List<int>();
            list.Add(6);
            list.Add(7);
            list.Add(19);
            list.Add(17);
            newList = Methods.FilterDigit(list, 7);
            foreach (int i in newList)
                Console.WriteLine(i);
            
            Console.WriteLine(Methods.InsertNumber(15,15,0,0));
            Console.ReadLine();
        }
    }
}
