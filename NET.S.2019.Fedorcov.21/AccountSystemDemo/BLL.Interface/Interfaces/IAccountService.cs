using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void AddBalance(Account account, decimal balance);
        void RemoveBalance(Account account, decimal balance);
        void OpenAccount(Account account);
        void CloseAccount(Account account);
        int BonusPoints(Account account, decimal balance);

    }
}
