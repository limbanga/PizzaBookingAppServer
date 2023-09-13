using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public interface IEmployeeRepository : IGenericRepository<Employee>
	{
		Task CreateUserAsync(Employee model, string password);
		Task<Employee?> LoginAsync(string loginName, string password);
	}
}