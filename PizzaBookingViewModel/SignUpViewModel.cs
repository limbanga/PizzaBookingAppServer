using System.ComponentModel.DataAnnotations;

namespace PizzaBookingViewModel
{
	public class SignUpViewModel
	{
		[EmailAddress]
		public string LoginName { get; set; } = null!;
		[MinLength(length: 8)]
		public string Password { get; set; } = null!;
		[Compare("Password")]
		public string RePassword { get; set; } = null!;
	}
}