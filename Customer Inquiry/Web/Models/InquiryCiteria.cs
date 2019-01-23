using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class InquiryCriteria
    {

        [MaxLength(10)]
        public string CustomerId { get; set; }

      //  [MaxLength(25)]
        [EmailAddress]
        public string Email { get; set; }

    }
}