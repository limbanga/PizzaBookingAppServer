using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppContext context) : base(context)
		{
		}
	}
}
