using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBookingShared.ViewModel
{
    public class ProductViewModel : TimeRecord
    {
        public int Id { get; set; }


        [
            Required,
            MaxLength(50)
        ]
        public string Name { get; set; } = null!;


        [MaxLength(500)]
        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        public int? CategoryId { get; set; }
        public CategoryViewModel? Category { get; set; }

        [
            Required,
            Range(0, 50)
        ]
        public float Price { get; set; }
    }
}
