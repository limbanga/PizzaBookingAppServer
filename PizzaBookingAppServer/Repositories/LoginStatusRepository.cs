using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public class LoginStatusRepository : GenericRepository<LoginStatus>, ILoginStatusRepository
	{
		public LoginStatusRepository(AppContext context) 
			: base(context)
		{

		}

	}
}
