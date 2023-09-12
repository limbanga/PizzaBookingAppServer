using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public interface IEmployeeRepository : IGenericRepository<Employee>
	{
		Task CreateSuperUserAsync(Employee model, string password);
	}
}