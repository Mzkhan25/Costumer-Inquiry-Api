using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    
    public class InquiryCriteria
    {

        [Range(0,9999999999,ErrorMessage ="Invalid Customer Id")]
        public int CustomerId { get; set; }

      //  [MaxLength(25)]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

    }
}