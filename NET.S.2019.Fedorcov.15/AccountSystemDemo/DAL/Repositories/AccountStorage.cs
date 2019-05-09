using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using System.IO;

namespace DAL.Repositories
{
    public class AccountStorage: IStorage
    {
        private string path;
        private List<DALAccount> list = new List<DALAccount>();
        public AccountStorage(string path)
        {
            this.path = path;
        }
        public void AddAccount(DALAccount account)
        {
            list.Add(account);
            SaveToFile();
        }
        public void RemoveAccount(DALAccount account)
        {
            list.Remove(account);
            SaveToFile();
        }
        public void DisplayStorage()
        {
            foreach (DALAccount acc in list)
            {
                Console.WriteLine(acc.ToString());
            }
        }
        public void SaveToFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (DALAccount acc in list)
                {
                    writer.Write(acc.ID);
                    writer.Write(acc.Firstname);
                    writer.Write(acc.Lastname);
                    writer.Write(acc.Balance);
                    writer.Write(acc.BonusPoints);
                    if (acc.Status == AccountStatus.Active)
                        writer.Write("Active");
                    else
                        writer.Write("Close");
                    if (acc.Type == AccountType.Base)
                        writer.Write("Base");
                    else
                    if (acc.Type == AccountType.Silver)
                        writer.Write("Silver");
                    else
                    if (acc.Type == AccountType.Gold)
                        writer.Write("Gold");
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
                    if (typeStr == "Base")
                        type = AccountType.Base;
                    else
                    if (typeStr == "Silver")
                        type = AccountType.Silver;
                    else
                        type = AccountType.Gold;
                    DALAccount acc = new DALAccount(number, type, firstname, lastname, balance, bonus);
                    acc.Status = status;
                    list.Add(acc);
                }
            }
        }
    }
}
