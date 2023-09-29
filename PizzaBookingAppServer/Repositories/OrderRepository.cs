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
	}
}
