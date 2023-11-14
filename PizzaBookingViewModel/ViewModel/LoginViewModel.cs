using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="required")]
        [EmailAddress]
        public string LoginName { get; set; } = null!;

        [Required(ErrorMessage = "required")]
        [MinLength(8, ErrorMessage = "at least {1} chacracters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
