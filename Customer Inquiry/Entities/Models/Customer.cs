using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Entities.Commons;

namespace Entities.Models
{
    public class Customer : BaseModel
    {

        // Class for Customer management

        [Range(1000000000, 9999999999,ErrorMessage ="Customer Id Must be 10 Digits")]
        [Required(ErrorMessage = "Customer Id must be specified")]
        public int CustomerId { get; set; }

        [MaxLength(25, ErrorMessage = "Name can not exceed 30 characters")]
        public string Name { get; set; }

        
        [MinLength(1, ErrorMessage = "Id can be max 10 digits long")]
        [MaxLength(25, ErrorMessage = "Id can be max 10 digits long")]
        [EmailAddress(ErrorMessage = "Kindly enter a valid Email")]
        public string Email{ get; set; }

        
        [Phone(ErrorMessage = "Kindly enter a valid mobile number format")]
        [MinLength(10, ErrorMessage = "Id can be max 10 digits long")]
        [MaxLength(10, ErrorMessage = "Id can be max 10 digits long")]
        public string Mobile { get; set; }
    }
}