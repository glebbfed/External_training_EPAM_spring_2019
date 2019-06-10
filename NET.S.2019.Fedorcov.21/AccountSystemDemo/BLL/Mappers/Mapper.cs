using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
namespace BLL.Mappers
{
    public static class Mapper
    {
        /// <summary>
        /// Converts BLL Account to DAL Account
        /// </summary>
        public static Account ConvertToAccount(this DALAccount dalAccount)
        {
            return new Account(dalAccount.ID, dalAccount.Type, dalAccount.Firstname, dalAccount.Lastname, dalAccount.Balance, dalAccount.BonusPoints);
        }

        /// <summary>
        /// Converts DAL Account to BLL Account
        /// </summary>
        public static DALAccount ConvertToDalAccount(this Account account)
        {
            return new DALAccount(account.Number, account.Type, account.Firstname, account.Lastname, account.Balance, account.BonusPoints);
        }
    }
}
