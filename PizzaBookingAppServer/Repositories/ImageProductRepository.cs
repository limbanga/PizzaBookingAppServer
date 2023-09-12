using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class ImageProductRepository : GenericRepository<ImageProduct>, IImageProductRepository
	{
		public ImageProductRepository(AppContext context) : base(context)
		{
		}
	}
}
