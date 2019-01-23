using System.Linq;
using Entities.Models;

namespace Contracts.IRepository
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> GetAll();
        TransactionResult Save(Transaction transaction);
        TransactionResult Delete(Transaction transaction);
    }
}