using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDataBaseContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbEntityEntry Entry(object o);
        void Dispose();

    }
}