using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingViewModel
{
    public class ProductViewModel : TimeRecord
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public int? CategoryId { get; set; }
        public CategoryViewModel? Category { get; set; }
        public float Price { get; set; }
    }
}
