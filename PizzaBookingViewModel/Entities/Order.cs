namespace PizzaBookingShared.Entities
{
	public class Order : TimeRecord
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public Customer? Customer { get; set; }
		public int? EmployeeId { get; set; }
		public Employee? Employee { get; set; }
	}
}
