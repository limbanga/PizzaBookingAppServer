using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingViewModel
{
	public class LoginViewModel
	{
		[EmailAddress]
		public string LoginName { get; set; } = null!;
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;
	}
}
