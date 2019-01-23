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

        [Range(1, 10, ErrorMessage = "Id can be max 10 digits long")]
        [Required(ErrorMessage = "Customer Id must be specified")]
        public int CustomerId { get; set; }

        [MaxLength(25, ErrorMessage = "Name can not exceed 30 characters")]
        public string Name { get; set; }

        [Range(1, 25, ErrorMessage = "Email can be max 25 digits long")]
        [EmailAddress(ErrorMessage = "Kindly enter a valid Email")]
        public string Email{ get; set; }

        
        [Phone(ErrorMessage = "Kindly enter a valid mobile number format")]
        [MinLength(10, ErrorMessage = "Id can be max 10 digits long")]
        [MaxLength(10, ErrorMessage = "Id can be max 10 digits long")]
        public int Mobile { get; set; }
    }
}