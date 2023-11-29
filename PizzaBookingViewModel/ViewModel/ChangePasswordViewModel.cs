using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "required"),
        MinLength(8, ErrorMessage ="at least {1} chacracters"),
        DataType(DataType.Password)]
        public string OldPassword { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "required"),
        MinLength(8, ErrorMessage = "at least {1} chacracters"),
        DataType(DataType.Password)]
        public string NewPassword { get; set; } = null!;
        [Required(ErrorMessage = "required"),
        MinLength(8, ErrorMessage = "at least {1} chacracters"),
        Compare("NewPassword", ErrorMessage = "doesn't match"),
        DataType(DataType.Password)]
        public string ConfirmPassword { get; set;} = string.Empty;
    }
}
