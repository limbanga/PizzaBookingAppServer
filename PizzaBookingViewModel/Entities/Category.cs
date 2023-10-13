using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Category : TimeRecord
	{
        public int Id { get; set; }
        [StringLength(50)]
		public string Name { get; set; } = null!;
        [StringLength(50)]
        public string? Alias { get; set; } 

        [Column(TypeName = "VARCHAR")]
        [StringLength(32)]
        public string Icon { get; set; } = null!;
        [JsonIgnore]
		public List<Product>? Products { get; set; }
		[NotMapped]
		[JsonIgnore]
        public int Count { get; set; }
    }
}