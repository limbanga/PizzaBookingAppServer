using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class CustomerController : GenericController<Customer>
	{
		public CustomerController(
			AppContext context,
			ICustomerRepository tRepo,
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }
	}
}
