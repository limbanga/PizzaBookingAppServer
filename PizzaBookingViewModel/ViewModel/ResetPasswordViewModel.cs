using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "required")]
		[EmailAddress(ErrorMessage = "ivalid email")]
		public string Email { get; set; } = null!;
	}
}
