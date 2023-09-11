namespace PizzaBookingAppServer.Entities
{
	public class EmployeeType : TimeRecord
	{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<IncludePermisson>? IncludePermissons { get; set; } 
    }
}