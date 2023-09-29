using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class ImageProductViewModel : TimeRecord
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ImagePath { get; set; } = null!;
        public int NumOrder { get; set; }
    }
}
