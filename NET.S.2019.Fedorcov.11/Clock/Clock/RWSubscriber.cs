using System;

namespace Clock
{
    public class RWSubscriber
    {
        //Subscribing for event
        public void Subscribe(ReverseWatch reverseWatch)
        {
            reverseWatch.Countdown += CountdownOver;
        }

        private void CountdownOver(object sender, RWEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
        }
    }
}
