namespace PizzaBookingAppServer.Entities
{
	public class EmployeePermission : TimeRecord
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public List<IncludePermisson>? IncludePermissons { get; set; }
		public List<HasPermission>? HasPermissions { get; set; }

	}
}
