using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IOrderLineRepository : IGenericRepository<OrderLine>
    {
        Task<IEnumerable<OrderLine>> GetByOrderIdAsync(int orderId);
    }

    public class OrderLineRepository : GenericRepository<OrderLine>, IOrderLineRepository
	{
		public OrderLineRepository(AppContext context) 
			: base(context)
		{
		}

        public async Task<IEnumerable<OrderLine>> GetByOrderIdAsync(int orderId)
        {
            var list = await _context.OrderLine
                        .Where(ol => ol.OrderId == orderId)
                        .ToListAsync();
            return list;
        }
    }
}
