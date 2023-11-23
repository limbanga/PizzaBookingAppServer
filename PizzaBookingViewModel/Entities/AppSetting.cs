using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.Entities
{
    public class AppSetting
    {
        public int Id { get; set; }
        public bool AllowAnonymousLogin { get; set; } = true;
        public bool Dense { get; set; } = true;
        public bool Hover { get; set; } = true;
        public bool Striped { get; set; } = true;
        public bool Bordered { get; set; } = false;
    }
}
