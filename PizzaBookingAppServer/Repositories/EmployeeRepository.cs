using Microsoft.AspNetCore.Identity;
using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(AppContext context) 
			: base(context)
		{ }

		public async Task CreateSuperUserAsync(Employee model, string password)
		{
			IPasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();
			model.HashedPassword = passwordHasher.HashPassword(model, password);
			model.FirstName = "Super_user_created";
			await CreateAsync(model);
		}
	}
}
