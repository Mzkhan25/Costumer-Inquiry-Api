using Entities.Commons;
using Entities.Commons.Enums;

namespace Entities.Models
{
    public class Transaction : BaseModel
    {
        public double Amount { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public long CustomerId { get; set; }
    }
}