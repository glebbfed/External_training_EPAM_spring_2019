using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseWatch reverseWatch = new ReverseWatch();
            RWSubscriber subscriber = new RWSubscriber();
            subscriber.Subscribe(reverseWatch);
            Console.WriteLine("Enter time: ");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();
            reverseWatch.StartCoundown(seconds, message);
            Console.ReadLine();
        }
    }
}
