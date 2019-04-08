using System;
using System.Collections.Generic;

namespace Task2
{
    public static class AccountService
    {
        public static void AddBalance(Account account, decimal balance)
        {
            if (AccountStatus.Active == account.Status)
            {
                account.Balance += balance;
                account.BonusPoints += BonusPoints(account, balance);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static void RemoveBalance(Account account, decimal balance)
        {
            if (AccountStatus.Active == account.Status && balance <= account.Balance)
            {
                account.Balance -= balance;
                account.BonusPoints -= BonusPoints(account, balance);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public static void CreateAccount(Account account, List<Account> list)
        {
            list.Add(account);
        }
        public static void CloseAccount(Account account)
        {
            account.Status = AccountStatus.Close;
        }
        public static int BonusPoints(Account account, decimal balance)
        {
            int bonus = 0;
            switch(account.Type)
            {
                case AccountType.Gold:
                    {
                        bonus = (int)(balance / 10);
                    }
                    break;
                case AccountType.Medium:
                    {
                        bonus = (int)(balance / 20);
                    }
                    break;
                case AccountType.Platinum:
                    {
                        bonus = (int)(balance / 5);
                    }
                    break;
            }
            return bonus;
        }
        

    }
}
