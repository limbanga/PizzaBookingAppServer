using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(AppContext context) 
			: base(context)
		{ }

        public override async Task<List<Order>> GetAllAsync()
        {
            var list =  await _context.Order
                .Include(o=> o.Customer)
                .Include(o => o.OrderLines)
                .ToListAsync();

            return list;
        }
    }
}
