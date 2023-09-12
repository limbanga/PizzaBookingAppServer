using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class HasPermissionRepository : GenericRepository<HasPermission>, IHasPermissionRepository
	{
		public HasPermissionRepository(AppContext context) : base(context)
		{
		}

		public async Task<List<EmployeePermission>> GetPermissionByUserId(int id)
		{
			return await _dbSet
				.Include(hp => hp.Permission)
				.Where(hp => hp.EmployeeId == id)
				.Select(hp => hp.Permission!)
				.ToListAsync();
		}
	}
}
