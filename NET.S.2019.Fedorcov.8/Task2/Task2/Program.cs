using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountStorage storage = new AccountStorage(@"C:\Users\Labrador\Desktop\EPAM\NET.S.2019.Fedorcov.8\Task2\storage.dat");
            Account account = new Account(321312, "Gleb", "Fedorcov", 20, 0, AccountType.Gold);
            storage.OpenAccount(account);
            storage.DisplayStorage();
            AccountService.AddBalance(account, 20);
            storage.DisplayStorage();
            AccountService.RemoveBalance(account, 10);
            storage.DisplayStorage();
            storage.SaveToFile();
            AccountService.CloseAccount(account);
            storage.LoadFromFile();
            storage.DisplayStorage();
            Console.ReadLine();
        }
    }
}
