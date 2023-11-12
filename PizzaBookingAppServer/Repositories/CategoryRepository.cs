using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
		Task<Category?> GetByAliasAsync(string alias);
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(AppContext context) : base(context)
		{
		}

		public async Task<Category?> GetByAliasAsync(string alias)
		{
			var result = await _dbSet.FirstOrDefaultAsync(x => x.Alias != null && x.Alias.Equals(alias));
			return result;
		}
	}
}
