using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingViewModel
{
    public class BaseRespone
    {
        public int ErrorCode = 0;
        public string ErrorDescription = string.Empty;

        public bool IsSucceed => ErrorCode == 0;
    }
}
