using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Models
{
    public class User
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} must have min length of {1} and max Length of {2}.")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "The {0} is required")]
        [RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} must have min length of {1} and max Length of {2}.")]
        [DataType(DataType.Text)]
        public string Address { get; set; } = "";

        [Required(ErrorMessage = "The {0} is required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = "";

        [DataType(DataType.Text)]
        [Display(Name = "User Type")]
        public string UserType { get; set; } = "";

        [DataType(DataType.Currency)]
        public decimal Money { get; set; }
    }
}