using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Product : TimeRecord
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public string? ImagePath { get; set; }
		public int? CategoryId { get; set; }
		[JsonIgnore]
		public Category? Category { get; set; }
		public float Price { get; set; }
		public List<ImageProduct>? ImageProducts { get; set; }
	}
}
