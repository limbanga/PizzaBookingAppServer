using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(AppContext context) 
			: base(context)
		{ }

	}
}
