using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext()
        {
            Database.Connection.ConnectionString =
                @"Data Source=GRIMREAPER;Initial Catalog=WATG_SLBenefitsPortal;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}