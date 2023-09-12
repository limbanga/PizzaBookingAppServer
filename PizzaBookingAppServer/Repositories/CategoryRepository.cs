using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppContext context) : base(context)
		{
		}
	}
}
