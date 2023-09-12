using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(AppContext context) : base(context)
		{
		}
	}
}
