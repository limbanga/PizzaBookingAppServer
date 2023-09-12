using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class HasPermissionController : GenericController<HasPermission>
	{
		private readonly IHasPermissionRepository repo;
		public HasPermissionController(
			AppContext context, 
			IHasPermissionRepository tRepo, 
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{
			repo = tRepo;
		}

		[HttpGet("/get-user-permission/{id}")]
		public async Task<ActionResult<List<EmployeePermission>>> GetPermissionByUserId(int id)
		{
			return await repo.GetPermissionByUserId(id);
		}
	}
}
