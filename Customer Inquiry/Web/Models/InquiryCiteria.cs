using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class InquiryCiteria
    {

        [MaxLength(10)]
        public int CustomerId { get; set; }

        [MaxLength(25)]
        [EmailAddress]
        public string Email { get; set; }

    }
}