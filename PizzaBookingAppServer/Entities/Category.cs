using AutoMapper.Configuration.Annotations;

namespace PizzaBookingAppServer.Entities
{
	public class Category : TimeRecord
	{
        public int Id { get; set; }
		public string Name { get; set; } = null!;
		public List<Product>? Products { get; set; }
	}
}