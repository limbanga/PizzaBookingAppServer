using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class OrderLineRepository : GenericRepository<OrderLine>, IOrderLineRepository
	{
		public OrderLineRepository(AppContext context) 
			: base(context)
		{
		}
	}
}
