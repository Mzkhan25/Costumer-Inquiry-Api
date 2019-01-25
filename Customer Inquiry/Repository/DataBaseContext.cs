using System.Data.Entity;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext()
        {
            Database.Connection.ConnectionString =
                @"Data Source=DESKTOP-D222E22\SQLEXPRESS;Initial Catalog=CustomerInquiry;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}