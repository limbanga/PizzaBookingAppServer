using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<int> CountByCategory(int categoryId);
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
    }
}
