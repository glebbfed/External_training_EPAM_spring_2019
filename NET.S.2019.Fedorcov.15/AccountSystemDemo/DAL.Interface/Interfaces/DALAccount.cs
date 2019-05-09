using BLL.Interface.Entities;

namespace DAL.Interface.Interfaces
{
    public class DALAccount
    {
        public int ID
        {
            get;
            private set;
        }

        public AccountType Type
        {
            get;
            private set;
        }

        public string Firstname
        {
            get;
            private set;
        }

        public string Lastname
        {
            get;
            private set;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public int BonusPoints
        {
            get;
            private set;
        }

        public AccountStatus Status { get; set; }

        public DALAccount(int id, AccountType type, string name, string lastname, decimal cash, int bonus)
        {
            ID = id;
            Type = type;
            Firstname = name;
            Lastname = lastname;
            Balance = cash;
            BonusPoints = bonus;
        }
    }
}
