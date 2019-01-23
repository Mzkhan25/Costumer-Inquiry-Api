using System.Linq;
using Entities.Models;

namespace Contracts.IRepository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();
        TransactionResult Save(Customer customer);
        TransactionResult Delete(Customer customer);
    }
}