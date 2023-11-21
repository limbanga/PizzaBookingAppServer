using System.ComponentModel.DataAnnotations;

namespace PizzaBookingShared.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="required"),
        MaxLength(50, ErrorMessage ="max {1} chacracters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage ="required"),
        MaxLength(50, ErrorMessage ="max {1} chacracters")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "required"),
        MaxLength (12, ErrorMessage = "max {1} chacracters"),
        RegularExpression("^(0[1-9][0-9]{8,9})$", ErrorMessage = "invalid phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "required"),
        EmailAddress(ErrorMessage ="invalid email")]
        public string LoginName { get; set; } = null!;

        [Required(ErrorMessage = "required"),
        MinLength(length: 8, ErrorMessage ="at least 8 chacracters")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "required"),
        MinLength(length: 8, ErrorMessage = "at least 8 chacracters"),
        Compare("Password", ErrorMessage ="not match")]
        public string RePassword { get; set; } = null!;
    }
}