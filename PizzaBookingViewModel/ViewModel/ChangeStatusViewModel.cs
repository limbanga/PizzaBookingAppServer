using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class ChangeStatusViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string State { get; set; } = string.Empty;
    }
}
