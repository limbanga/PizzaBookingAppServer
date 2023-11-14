using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> CountByCategory(int categoryId);
        Task<List<Product>> GetAllWithCategoryAsync();
		Task<List<Product>> GetAllByCategoryAliasAsync(string alias);
		Task<List<Product>> FillterAsync(string? name = null, string? categoryAlias = null);

	}

	public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppContext context)
            : base(context)
        { }

        public async Task<int> CountByCategory(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId.Equals(categoryId)).CountAsync();
        }

		public async Task<List<Product>> FillterAsync(string? name = null, string? alias = null)
		{
            var query = _dbSet.AsQueryable();

			if (!string.IsNullOrWhiteSpace(alias))
			{
				query = query.Where(p =>
				    p.Category != null &&
				    p.Category.Alias != null &&
                    p.Category.Alias.Equals(alias))
                    .AsQueryable();
			}

			if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name))
                            .AsQueryable();
			}

            string text = query.ToQueryString();

            var result = await query.ToListAsync();
            return result;
		}

		public async Task<List<Product>> GetAllByCategoryAliasAsync(string alias)
		{
			return await _dbSet
                .Where(p => p.Category!.Alias!.Equals(alias))
                .OrderByDescending(p => p.Id)
                .ToListAsync();
		}

		public async Task<List<Product>> GetAllWithCategoryAsync()
        {
            return await _dbSet.Include(p => p.Category).ToListAsync();
        }
    }
}
