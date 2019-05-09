using System;
namespace BLL.Interface.Entities
{
    public class Account
    {
        public int Number { get; set; }
        public AccountType Type { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Balance { get; set; }
        public int BonusPoints { get; set; }
        public AccountStatus Status { get; set; }
        

        public Account(int number, AccountType type, string firstname, string lastname, decimal balance, int bonus)
        {
            Number = number;
            Firstname = firstname;
            Lastname = lastname;
            Balance = balance;
            BonusPoints = bonus;
            Status = AccountStatus.Active;
            Type = type;
        }

        public override string ToString()
        {
            return "Number: " + Number.ToString() + " Firstname: " + Firstname + " Lastname: " + Lastname + " Balance " + Balance.ToString();
        }
    }
}
