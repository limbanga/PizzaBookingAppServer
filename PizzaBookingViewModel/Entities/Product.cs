using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Product : TimeRecord
	{
		public int Id { get; set; }
        [Required,
		StringLength(50, ErrorMessage ="max length {1} chacracters")]
		public string Name { get; set; } = null!;
		[MaxLength(50)]
		public string? Alias { get; set; }
		[StringLength(100)]
        public string? ImagePath { get; set; }
		public int? CategoryId { get; set; }
		[JsonIgnore]
		public Category? Category { get; set; }
		[Range(0, double.MaxValue, ErrorMessage ="{0} must be positive.")]
		public double Price { get; set; }
    }
}
