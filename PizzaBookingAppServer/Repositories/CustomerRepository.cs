using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> LoginAsync(string loginName, string password);
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(AppContext context) : base(context)
		{
		}

        public async Task<Customer?> LoginAsync(string loginName, string password)
        {
            var customer = await _context.Customer.
                            Where(c => c.LoginName.Equals(loginName))
                            .FirstOrDefaultAsync();

            if (customer == null)
            {
                throw new AuthException();
            }

            IPasswordHasher<Customer> passwordHasher = new PasswordHasher<Customer>();
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(customer, customer.HashedPassword, password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new AuthException();
            }

            return customer;
        }
    }
}
