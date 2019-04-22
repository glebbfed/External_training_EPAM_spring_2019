using System;

namespace Clock
{
    public class RWEventArgs: EventArgs
    {       
        public int Seconds { get; }

        public string Message { get; }

        public RWEventArgs(int seconds, string message)
        {
            Seconds = seconds;
            Message = message;
        }
    }
}
