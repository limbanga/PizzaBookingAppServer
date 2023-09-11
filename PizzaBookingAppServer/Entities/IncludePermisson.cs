namespace PizzaBookingAppServer.Entities
{
	public class IncludePermisson
	{
        public int Id { get; set; }
		public int? PermissionId { get; set; }
		public EmployeePermission? Permission { get; set; }
		public int? EmployeeTypeId { get; set; }
		public EmployeeType? EmployeeType { get; set; }
	}
}
