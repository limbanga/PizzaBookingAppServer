using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class EmployeeTypeRepository : GenericRepository<EmployeeType>, IEmployeeTypeRepository
	{
		public EmployeeTypeRepository(AppContext context) : base(context)
		{
		}
	}
}
