using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class IncludePermissonViewModel
    {
        public int Id { get; set; }
        public int? PermissionId { get; set; }
        public int? EmployeeTypeId { get; set; }
    }
}
