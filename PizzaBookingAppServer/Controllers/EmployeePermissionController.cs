using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class EmployeePermissionController : GenericController<EmployeePermission>
	{
		public EmployeePermissionController(
			AppContext context, 
			IEmployeePermissonRepository tRepo, 
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }
	}
}
