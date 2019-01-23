using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class TransactionResult
    {
        // This class is to manage the transaction result, to store error messages. 

        public int Id { get; set; }
        public bool HasError { get; set; }
        public bool HasWarning { get; set; }
        public string Message{ get; set; }
        
    }
}