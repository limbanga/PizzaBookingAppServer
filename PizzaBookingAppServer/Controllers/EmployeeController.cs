using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;
using PizzaBookingViewModel;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class EmployeeController : GenericController<Employee>
	{
		private readonly IEmployeeRepository repo;
		public EmployeeController(
			AppContext context,
			IEmployeeRepository tRepo, 
			IMapper mapper)
			: base(context, tRepo, mapper)
		{
			repo = tRepo;
		}

		[HttpPost("/create-super-user")]
		public async Task<ActionResult> CreateSuperUser(SignUpViewModel model)
		{
			var employee = _mapper.Map<Employee>(model);
			await repo.CreateSuperUserAsync(employee, model.Password);
            return Ok(employee);
		}
	}
}
