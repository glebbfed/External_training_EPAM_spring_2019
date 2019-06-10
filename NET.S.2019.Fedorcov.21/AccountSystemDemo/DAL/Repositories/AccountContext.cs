using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    class AccountContext: DbContext
    {
        public AccountContext()
            : base("DbConnection")
        { }

        public DbSet<DALAccount> Accounts { get; set; }
    }
}
