using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(AppContext context) 
			: base(context)
		{ }
	}
}
