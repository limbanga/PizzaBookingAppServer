using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task CreateUserAsync(Employee model, string password);
        Task<Employee?> LoginAsync(string loginName, string password);
    }

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
			var employee = await _dbSet.FirstOrDefaultAsync(x => x.LoginName == loginName);
			if (employee == null)
			{
				throw new AuthException();
			}

            IPasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();
            var result = passwordHasher.VerifyHashedPassword(employee, employee.HashedPassword, password);
            if (result != PasswordVerificationResult.Success)
            {
                throw new AuthException();
			}

			return employee;
        }
	}
}
