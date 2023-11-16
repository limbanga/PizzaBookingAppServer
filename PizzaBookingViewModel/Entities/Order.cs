using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Order : TimeRecord
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		[JsonIgnore]
		public User? Customer { get; set; }
		[MaxLength(20)]
		public string? State { get; set; } = null;
		[Required(ErrorMessage = "required")]
        [MaxLength(15, ErrorMessage = "Invalid phone number")]
		[StringLength(15)]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "required")]
        [MaxLength(200, ErrorMessage = "Max length 200 chacracters")]
        [StringLength(200)]
        public string Address { get; set; } = null!;
        public List<OrderLine>? OrderLines { get; set; }
	}
}
