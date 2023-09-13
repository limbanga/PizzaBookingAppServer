using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;
using PizzaBookingViewModel;

namespace PizzaBookingAppServer.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class SetUpController : ControllerBase
	{
        private readonly ILoginStatusRepository _loginStatusRepo;
		private readonly IEmployeeTypeRepository _employeeTypeRepo;
		private readonly IEmployeePermissonRepository _employeePermissonRepo;
		private readonly IEmployeeRepository _employeeRepo;
		private readonly IMapper _mapper;

		public SetUpController(
			ILoginStatusRepository loginStatusRepo,
			IEmployeeTypeRepository employeeTypeRepo,
			IEmployeePermissonRepository employeePermissonRepo,
			IMapper mapper,
			IEmployeeRepository employeeRepo)
		{
			_loginStatusRepo = loginStatusRepo;
			_employeeTypeRepo = employeeTypeRepo;
			_employeePermissonRepo = employeePermissonRepo;
			_mapper = mapper;
			_employeeRepo = employeeRepo;
		}

		[HttpGet("inital-app")]
		public async Task<ActionResult> Index()
		{
			await _createEmployeeType();
			await _createEmployPermission();
			await _createLoginStatus();
			return Ok("Setup ok!");
		}

		[HttpPost("/create-admin")]
		public async Task<ActionResult> CreateSuperUser(SignUpViewModel model)
		{
            var adminRole = await _employeeTypeRepo.FindByNameAsync("Admin");
			if (adminRole is null)
			{
				return Problem("You must set up app first.");
			}
			
			var employee = _mapper.Map<Employee>(model);
			employee.Type = adminRole;
			await _employeeRepo.CreateUserAsync(employee, model.Password);
			return Ok(employee);
		}

		//----------------------------------------------------
		// Helper function
		//----------------------------------------------------

		private async Task _createEmployeeType()
		{
			await _employeeTypeRepo.CreateAsync(
				new Entities.EmployeeType()
				{
					Name = "Admin"
				}
			);
		}

		private async Task _createEmployPermission()
		{
			await _employeePermissonRepo.CreateAsync(
				new Entities.EmployeePermission()
				{
					Name = "Can abc"
				}
			);

			await _employeePermissonRepo.CreateAsync(
				new Entities.EmployeePermission()
				{
					Name = "Can zyx"
				}
			);
		}

		private async Task _createLoginStatus()
		{
			await _loginStatusRepo.CreateAsync(
				new Entities.LoginStatus()
				{
					Name = "Open"
				}
			);

			await _loginStatusRepo.CreateAsync(
				new Entities.LoginStatus()
				{
					Name = "Locked"
				}
			);
		}
	}
}
