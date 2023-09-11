namespace PizzaBookingAppServer.Entities
{
	public class HasPermission
	{
		public int Id { get; set; }
		public int? EmployeeId { get; set; }
		public Employee? Employee { get; set; }
		public int? PermissionId { get; set; }
		public EmployeePermission? Permission { get; set; }
	}
}