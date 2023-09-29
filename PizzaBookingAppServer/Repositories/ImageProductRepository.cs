using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IImageProductRepository : IGenericRepository<ImageProduct>
    {
    }

    public class ImageProductRepository : GenericRepository<ImageProduct>, IImageProductRepository
	{
		public ImageProductRepository(AppContext context) : base(context)
		{
		}
	}
}
