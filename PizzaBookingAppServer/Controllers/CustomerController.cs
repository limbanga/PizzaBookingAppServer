using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;

namespace PizzaBookingShared.Controllers
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
