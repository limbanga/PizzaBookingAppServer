using System.Text.Json.Serialization;

namespace PizzaBookingShared.Entities
{
	public class Order : TimeRecord
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		[JsonIgnore]
		public User? Customer { get; set; }
		public string? State { get; set; } = null;
		public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<OrderLine>? OrderLines { get; set; }
	}
}
