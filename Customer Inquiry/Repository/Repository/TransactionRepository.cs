using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Contracts;
using Contracts.IRepository;
using Entities.Models;

namespace Repository.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDataBaseContext _db;
        public TransactionRepository()
        {
            _db = new DataBaseContext();
        }
        public TransactionRepository(IDataBaseContext db)
        {
            _db = db;
        }

        public IQueryable<Transaction> GetAll()
        {
            return _db.Transactions.Where(p => p.IsDeleted == false);
        }

        public TransactionResult Save(Transaction transaction)
        {
            var result = new TransactionResult();
            try
            {
                var isNew = false;
                var dbItem = _db.Transactions.Find(transaction.Id);
                if (dbItem != null && transaction.Id != 0)
                {
                    _db.Entry(dbItem).State = EntityState.Modified;
                }
                else
                {
                    dbItem = transaction;
                    dbItem.DateAdded = DateTime.UtcNow;
                    
                    isNew = true;
                }
                
                
                dbItem.DateModified = DateTime.UtcNow;
                dbItem.Amount = transaction.Amount;
                dbItem.CurrencyCode = transaction.CurrencyCode;
                dbItem.TransactionStatus = transaction.TransactionStatus;
                dbItem.CustomerId = transaction.CustomerId;

                if (isNew)
                {
                    _db.Entry(dbItem).State = EntityState.Added;
                    _db.Transactions.Add(dbItem);
                }
                _db.SaveChanges();
                result.HasError = false;
            }
            catch (Exception exception)
            {
                result = TransactionError(exception);
            }
            return result;
        }

        public TransactionResult Delete(int id)
        {
            var result = new TransactionResult();
            try
            {
                var dbitem = _db.Transactions.Find(id);
                if (dbitem != null)
                {
                    dbitem.DateModified = DateTime.UtcNow;
                    dbitem.IsDeleted = true;
                    dbitem.DateModified = DateTime.UtcNow;
                    _db.Entry(dbitem).State = EntityState.Modified;
                }
                _db.SaveChanges();
                result.HasError = false;
            }
            catch (Exception exception)
            {
                result = TransactionError(exception);
            }
            return result;
        }
        private static TransactionResult TransactionError(Exception exception)
        {
            var transactionResult = new TransactionResult
            {
                HasError = true,
                Message = exception.Message
            };
            return transactionResult;
        }
    }
}