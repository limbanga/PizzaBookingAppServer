using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<ActionResult<List<Order>>> GetAllIncludeCustomerAsync();
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(AppContext context) 
			: base(context)
		{ }

        public async Task<ActionResult<List<Order>>> GetAllIncludeCustomerAsync()
        {
            return await _context.Order.Include(o => o.Customer).ToListAsync();
        }
    }
}
