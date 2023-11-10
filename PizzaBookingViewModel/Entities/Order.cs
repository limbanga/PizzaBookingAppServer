namespace PizzaBookingShared.Entities
{
	public class Order : TimeRecord
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public User? Customer { get; set; }
		public int? EmployeeId { get; set; }
	}
}
