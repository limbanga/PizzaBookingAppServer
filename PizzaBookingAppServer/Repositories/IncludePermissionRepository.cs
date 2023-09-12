using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class IncludePermissionRepository : GenericRepository<IncludePermisson>, IIncludePermissionRepository
	{
		public IncludePermissionRepository(AppContext context) 
			: base(context)
		{ }
	}
}
