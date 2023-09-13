using System.ComponentModel.DataAnnotations;

namespace PizzaBookingViewModel
{
	public class SignUpViewModel
	{
		[StringLength(maximumLength: 50, MinimumLength = 4)]
		public string FirstName { get; set; } = null!;
		[StringLength(maximumLength: 50, MinimumLength = 4)]
		public string LastName { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		[EmailAddress]
		public string LoginName { get; set; } = null!;
		[MinLength(length: 8)]
		public string Password { get; set; } = null!;
		[Compare("Password")]
		public string RePassword { get; set; } = null!;
	}
}