using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{

		public CustomerRepository(AppContext context) : base(context)
		{
		}
	}
}
