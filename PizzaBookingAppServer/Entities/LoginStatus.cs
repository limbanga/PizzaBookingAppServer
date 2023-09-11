namespace PizzaBookingAppServer.Entities
{
	public class LoginStatus : TimeRecord
	{
        public int Id { get; set; }
		public string Name { get; set; } = null!;
	}
}