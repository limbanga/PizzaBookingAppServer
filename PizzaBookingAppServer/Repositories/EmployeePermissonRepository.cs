using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class EmployeePermissonRepository : GenericRepository<EmployeePermission>, IEmployeePermissonRepository
	{
		public EmployeePermissonRepository(AppContext context) 
			: base(context)
		{
		}
	}
}
