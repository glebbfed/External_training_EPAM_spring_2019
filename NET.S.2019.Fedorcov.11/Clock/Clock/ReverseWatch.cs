using System;
using System.Threading;

namespace Clock
{
    public class ReverseWatch
    {
        public delegate void RWEventHandler(object sender, RWEventArgs e);

        public event RWEventHandler Countdown = delegate { };

        private void OnCountdown(object sender, RWEventArgs e)
        {
            Countdown.Invoke(sender, e);
        }
        /// <summary>
        /// Method that starts counting.
        /// </summary>
        public void StartCoundown(int seconds, string message)
        {
            if (seconds < 0)
            {
                throw new ArgumentException();
            }

            Thread.Sleep(seconds * 1000);
            OnCountdown(this, new RWEventArgs(seconds, message));
        }
    }
}
