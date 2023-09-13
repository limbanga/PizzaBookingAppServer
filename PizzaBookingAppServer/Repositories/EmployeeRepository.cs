using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(AppContext context) 
			: base(context)
		{ }

		public async Task CreateUserAsync(Employee model, string password)
		{
			IPasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();
			model.HashedPassword = passwordHasher.HashPassword(model, password);
			model.Email = model.LoginName;
			await CreateAsync(model);
		}

		public async Task<Employee?> LoginAsync(string loginName, string password)
		{
			IPasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();
			var employee = await _dbSet.FirstOrDefaultAsync(x => x.LoginName == loginName);
			if (employee == null)
			{
				return null;
			}
			var result = passwordHasher.VerifyHashedPassword(employee, employee.HashedPassword, password);
            if (result != PasswordVerificationResult.Success)
            {
				return null;
			}
			return employee;
        }
	}
}
