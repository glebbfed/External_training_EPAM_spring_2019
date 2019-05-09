using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService: IAccountService
    {
        public void AddBalance(Account account, decimal balance)
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
        public void RemoveBalance(Account account, decimal balance)
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
        public void OpenAccount(Account account)
        {
            account.Status = AccountStatus.Active;
        }
        public void CloseAccount(Account account)
        {
            account.Status = AccountStatus.Close;
        }
        public int BonusPoints(Account account, decimal balance)
        {
            int bonus = 0;
            switch (account.Type)
            {
                case AccountType.Base:
                    {
                        bonus = (int)(balance / 10);
                    }
                    break;
                case AccountType.Silver:
                    {
                        bonus = (int)(balance / 20);
                    }
                    break;
                case AccountType.Gold:
                    {
                        bonus = (int)(balance / 5);
                    }
                    break;
            }
            return bonus;
        }


    }
}
