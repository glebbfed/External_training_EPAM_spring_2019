using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccount
    {
        int Number { get; set; }
        AccountType Type { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        decimal Balance { get; set; }
        int BonusPoints { get; set; }
        AccountStatus Status { get; set; }
    }
}
