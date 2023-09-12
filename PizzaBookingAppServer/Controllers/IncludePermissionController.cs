using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class IncludePermissionController : GenericController<IncludePermisson>
	{
		public IncludePermissionController(
			AppContext context,
			IIncludePermissionRepository tRepo,
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }
	}
}
