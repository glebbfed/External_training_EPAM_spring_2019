using System;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using System.IO;
using System.Linq;

namespace DAL.Repositories
{
    public class AccountStorage: IStorage
    {
        private string path;
        AccountContext db = new AccountContext();
        public AccountStorage(string path)
        {
            this.path = path;
        }
        /// <summary>
        /// This method adds account in our database.
        /// </summary>
        /// <param name="account">Adding account.</param>
        public void AddAccount(DALAccount account)
        {
            if (!db.Accounts.Any(x => x.ID == account.ID))
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            else
                Console.WriteLine("Such element already exist!");
            
        }
        /// <summary>
        /// This method remove account from our database by id.
        /// </summary>
        /// <param name="id">ID of account</param>
        public void RemoveAccount(int id)
        {
            if (db.Accounts.Any(x => x.ID == id))
            {
                DALAccount acc = db.Accounts
                .Where(x => x.ID == id)
                .Select(x => x)
                .First();
                db.Accounts.Remove(acc);
                db.SaveChanges();
            }
            else
                Console.WriteLine("No such element exist");
        }
        /// <summary>
        /// This method display content of our database by console.
        /// </summary>
        public void DisplayStorage()
        {
            var accs = db.Accounts;
            foreach (DALAccount acc in accs)
            {
                Console.WriteLine(acc.ID + acc.Firstname + acc.Lastname);
            }
        }
        /// <summary>
        /// This method removes all content from our database.
        /// </summary>
        public void Clear()
        {
            foreach(DALAccount acc in db.Accounts)
            {
                
                db.Accounts.Attach(acc);
                db.Accounts.Remove(acc);                
            }
            db.SaveChanges();
        }
        /// <summary>
        /// This method saves content of our database into text file.
        /// </summary>
        public void SaveToFile()
        {
            var accs = db.Accounts;
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (DALAccount acc in accs)
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
        /// <summary>
        /// This method loads content from text file to our database.
        /// </summary>
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
                    this.AddAccount(acc);
                }
            }
        }
    }
}
