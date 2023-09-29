namespace PizzaBookingShared.Entities
{
	public class ImageProduct : TimeRecord
	{
        public int Id { get; set; }
		public int? ProductId  { get; set; }
		public Product? Product { get; set; }
		public string ImagePath { get; set; } = null!;
		public int NumOrder { get; set; }
	}
}