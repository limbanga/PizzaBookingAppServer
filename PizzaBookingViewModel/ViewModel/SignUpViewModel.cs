using System.ComponentModel.DataAnnotations;

namespace PizzaBookingShared.ViewModel
{
    public class SignUpViewModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string FirstName { get; set; } = null!;


        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string LoginName { get; set; } = null!;


        [MinLength(length: 8)]
        public string Password { get; set; } = null!;


        [Compare("Password")]
        public string RePassword { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}