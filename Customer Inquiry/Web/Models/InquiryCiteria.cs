using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class InquiryCriteria
    {
        [Range(0, 9999999999, ErrorMessage = "Invalid Customer Id")]
        public long CustomerId { get; set; }

        //  [MaxLength(25)]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}