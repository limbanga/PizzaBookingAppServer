namespace PizzaBookingAppServer.Entities
{
	public class Employee : User
	{
		public int? TypeId { get; set; }
		public EmployeeType? Type { get; set; }
		List<HasPermission>? Permissions { get; set;}
    }
}
