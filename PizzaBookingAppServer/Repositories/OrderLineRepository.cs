using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IOrderLineRepository : IGenericRepository<OrderLine>
    {
    }

    public class OrderLineRepository : GenericRepository<OrderLine>, IOrderLineRepository
	{
		public OrderLineRepository(AppContext context) 
			: base(context)
		{
		}
	}
}
