using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class HasPermissionViewModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? PermissionId { get; set; }
    }
}
