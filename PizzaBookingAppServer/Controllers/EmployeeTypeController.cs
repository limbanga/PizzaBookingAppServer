using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class EmployeeTypeController : GenericController<EmployeeType>
	{
		public EmployeeTypeController(
			AppContext context,
			IEmployeeTypeRepository tRepo, 
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }
	}
}
