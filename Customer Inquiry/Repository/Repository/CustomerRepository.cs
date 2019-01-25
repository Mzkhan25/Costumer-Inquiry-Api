using System;
using System.Data.Entity;
using System.Linq;
using Contracts;
using Contracts.IRepository;
using Entities.Models;

namespace Repository.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataBaseContext _db;

        public CustomerRepository()
        {
            _db = new DataBaseContext();
        }

        public CustomerRepository(IDataBaseContext db)
        {
            _db = db;
        }

        public IQueryable<Customer> GetAll()
        {
            return _db.Customers.Where(p => p.IsDeleted == false);
        }

        public TransactionResult Save(Customer customer)
        {
            var result = new TransactionResult();
            try
            {
                var isNew = false;
                var dbItem = _db.Customers.Find(customer.Id);
                if (dbItem != null && customer.Id != 0)
                {
                    _db.Entry(dbItem).State = EntityState.Modified;
                }
                else
                {
                    dbItem = customer;
                    dbItem.DateAdded = DateTime.UtcNow;

                    isNew = true;
                }


                dbItem.DateModified = DateTime.UtcNow;
                dbItem.CustomerId = customer.CustomerId;
                dbItem.Name = customer.Name;
                dbItem.Email = customer.Email;
                dbItem.Mobile = customer.Mobile;

                if (isNew)
                {
                    _db.Entry(dbItem).State = EntityState.Added;
                    _db.Customers.Add(dbItem);
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
                var dbitem = _db.Customers.Find(id);
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