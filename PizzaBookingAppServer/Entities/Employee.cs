namespace PizzaBookingAppServer.Entities
{
	public class Employee : User
	{
		public int? TypeId { get; set; }
		public EmployeeType? Type { get; set; }
		public bool IsSuperUser { get; set; } = false;
		List<HasPermission>? Permissions { get; set;}
    }
}
