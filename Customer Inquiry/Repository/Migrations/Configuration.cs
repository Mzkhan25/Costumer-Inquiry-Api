using System;
using System.Data.Entity.Migrations;
using Entities.Commons.Enums;
using Entities.Models;

namespace Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataBaseContext context)
        {
            context.Customers.AddOrUpdate(
                new Customer
                {
                    CustomerId = 1234567890,
                    Name = "Firstname Lastname",
                    Email = "user@domain.com",
                    Mobile = "0123456789",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Customer
                {
                    CustomerId = 6789012345,
                    Name = "John Doe",
                    Email = "johndoe@domain.com",
                    Mobile = "1234560789",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Customer
                {
                    CustomerId = 1237456890,
                    Name = "Joe Dane",
                    Email = "joedane@domain.com",
                    Mobile = "0789123456",
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
            context.Transactions.AddOrUpdate(
                new Transaction
                {
                    CustomerId = 1234567890,
                    Amount = 784.687,
                    CurrencyCode = CurrencyCode.SGD,
                    TransactionStatus = TransactionStatus.Success,
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Transaction
                {
                    CustomerId = 1234567890,
                    Amount = 741.54,
                    CurrencyCode = CurrencyCode.JPY,
                    TransactionStatus = TransactionStatus.Canceled,
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Transaction
                {
                    CustomerId = 1234567890,
                    Amount = 365.41254,
                    CurrencyCode = CurrencyCode.USD,
                    TransactionStatus = TransactionStatus.Failed,
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Transaction
                {
                    CustomerId = 6789012345,
                    Amount = 214.648,
                    CurrencyCode = CurrencyCode.JPY,
                    TransactionStatus = TransactionStatus.Success,
                    DateAdded = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
}