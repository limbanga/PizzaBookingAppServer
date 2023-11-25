using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Product : TimeRecord
	{
		public int Id { get; set; }
        [Required]
        [StringLength(50)]
		public string Name { get; set; } = null!;
		[StringLength(100)]
        public string? ImagePath { get; set; }
		public int? CategoryId { get; set; }
		[JsonIgnore]
		public Category? Category { get; set; }
		[Range(0, double.MaxValue)]
		public double Price { get; set; }
	}
}
