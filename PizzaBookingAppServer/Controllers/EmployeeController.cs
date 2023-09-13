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
		private readonly IEmployeeTypeRepository employeeTypeRepo;
		private readonly IEmployeeRepository repo;
		public EmployeeController(
			AppContext context,
			IEmployeeRepository tRepo,
			IMapper mapper,
			IEmployeeTypeRepository employeeTypeRepo)
			: base(context, tRepo, mapper)
		{
			repo = tRepo;
			this.employeeTypeRepo = employeeTypeRepo;
		}

		[HttpPost]
		public async Task<ActionResult> Create(SignUpViewModel model)
		{
			Employee employee = _mapper.Map<Employee>(model);
			await repo.CreateUserAsync(employee, model.Password);
			return Ok("Create employee successfully.");
		}

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel model)
		{
			Employee? employee = await repo.LoginAsync(model.LoginName, model.Password);
            if (employee is null)
            {
				return Problem("Username or password doesn't exists.");
            }
            return Ok("Login employee successfully.");
		}

		[NonAction]
		public override Task<ActionResult> Create(Employee model)
		{
			return base.Create(model);
		}

		public override Task<ActionResult> Delete(int id)
		{
			return base.Delete(id);
		}

		public override Task<ActionResult<Employee>> Get(int id)
		{
			return base.Get(id);
		}

		public override Task<ActionResult<List<Employee>>> GetAll()
		{
			return base.GetAll();
		}

		public override Task<ActionResult> Update(Employee model)
		{
			return base.Update(model);
		}
	}
}
