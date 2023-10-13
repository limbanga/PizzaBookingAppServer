using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> CountByCategory(int categoryId);
        Task<List<Product>> GetAllWithCategoryAsync();
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

        public async Task<List<Product>> GetAllWithCategoryAsync()
        {
            return await _dbSet.Include(p => p.Category).ToListAsync();
        }
    }
}
