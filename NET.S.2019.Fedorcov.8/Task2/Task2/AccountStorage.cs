using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    public class AccountStorage
    {
        private string path;
        private List<Account> list = new List<Account>();
        public AccountStorage(string path)
        {
            this.path = path;
        }
        public void OpenAccount(Account account)
        {
            AccountService.CreateAccount(account, list);
        }
        public void CloseAccount(Account account)
        {
            AccountService.CloseAccount(account);
        }
        public void DisplayStorage()
        {
            foreach(Account acc in list)
            {
                Console.WriteLine(acc.ToString());
            }
        }
        public void SaveToFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Account acc in list)
                {
                    writer.Write(acc.Number);
                    writer.Write(acc.Firstname);
                    writer.Write(acc.Lastname);
                    writer.Write(acc.Balance);
                    writer.Write(acc.BonusPoints);
                    if (acc.Status == AccountStatus.Active)
                        writer.Write("Active");
                    else
                        writer.Write("Close");
                    if (acc.Type == AccountType.Gold)
                        writer.Write("Gold");
                    else
                    if (acc.Type == AccountType.Medium)
                        writer.Write("Medium");
                    else
                    if (acc.Type == AccountType.Platinum)
                        writer.Write("Platinum");
                }
            }

        }
        public void LoadFromFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    int number = reader.ReadInt32();
                    string firstname = reader.ReadString();
                    string lastname = reader.ReadString();
                    decimal balance = reader.ReadDecimal();
                    int bonus = reader.ReadInt32();
                    string statusStr = reader.ReadString();
                    AccountStatus status;
                    if (statusStr == "Active")
                        status = AccountStatus.Active;
                    else
                        status = AccountStatus.Close;
                    string typeStr = reader.ReadString();
                    AccountType type;
                    if (typeStr == "Medium")
                        type = AccountType.Medium;
                    else
                    if (typeStr == "Gold")
                        type = AccountType.Gold;
                    else
                        type = AccountType.Platinum;
                    Account acc = new Account(number, firstname, lastname, balance, bonus, type);
                    acc.Status = status;
                    list.Add(acc);
                }
            }
        }
    }
}
