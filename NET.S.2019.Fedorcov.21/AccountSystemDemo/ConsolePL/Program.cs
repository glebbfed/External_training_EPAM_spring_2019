using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using BLL.Mappers;
using DependencyResolver;
using Ninject;
using System;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
           
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();
            IStorage storage = resolver.Get<IStorage>();
            storage.RemoveAccount(3);
            storage.Clear();
            Account acc = new Account(1, AccountType.Base, "Gleb", "Fedorcov", 100, 5);
            storage.AddAccount(acc.ConvertToDalAccount());
            storage.DisplayStorage();            
            Console.ReadLine();
        }
    }
}
