using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Commons;
using Entities.Commons.Enums;

namespace Entities.Models
{
    public class Transaction : BaseModel
    {
        public float Amount { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public string CustomerId { get; set; }
    }
}