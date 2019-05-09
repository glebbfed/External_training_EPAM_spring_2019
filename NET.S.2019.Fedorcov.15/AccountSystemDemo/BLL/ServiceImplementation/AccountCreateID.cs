using System;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountCreateID: IAccountCreateID
    {
        private static Random random = new Random(new Random(DateTime.Now.Second + DateTime.Now.Millisecond).Next((int)DateTime.Now.TimeOfDay.TotalMilliseconds));

        /// <summary>
        /// Generates random ID
        /// </summary>
        public int CreateID()
        {
            const int number = 1000;
            return random.Next(number);
        }
    }
}
