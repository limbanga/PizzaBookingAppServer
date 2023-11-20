using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Category : TimeRecord
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="required"), 
        StringLength(50, ErrorMessage = "max 50 chacracters")]
		public string Name { get; set; } = null!;
        [StringLength(50)]
        public string? Alias { get; set; } 
        [JsonIgnore]
		public List<Product>? Products { get; set; }
    }
}