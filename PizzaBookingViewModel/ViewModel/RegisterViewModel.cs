using System.ComponentModel.DataAnnotations;

namespace PizzaBookingShared.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="required")]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage ="required")]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "required")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "required")]
        [EmailAddress]
        public string LoginName { get; set; } = null!;

        [Required(ErrorMessage = "required")]
        [MinLength(length: 8)]
        public string Password { get; set; } = null!;


        [Compare("Password")]
        public string RePassword { get; set; } = null!;
    }
}