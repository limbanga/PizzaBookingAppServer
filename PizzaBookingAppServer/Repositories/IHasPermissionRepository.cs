using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public interface IHasPermissionRepository : IGenericRepository<HasPermission>
	{
		Task<List<EmployeePermission>> GetPermissionByUserId(int id);
	}
}