using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class EmployeeTypeRepository : GenericRepository<EmployeeType>, IEmployeeTypeRepository
	{
		public EmployeeTypeRepository(AppContext context) 
			: base(context)
		{
		}

		public async Task<EmployeeType?> FindByNameAsync(string name)
		{
			return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
		}
	}
}
