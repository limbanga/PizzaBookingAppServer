using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Identity;
using PizzaBookingShared.Repositories;
using PizzaBookingShared.ViewModel;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaBookingShared.Controllers
{
    [ApiController]
	public class EmployeeController : GenericController<Employee>
	{
		private readonly IEmployeeRepository repo;
		private readonly IConfiguration _configuration;

		public EmployeeController(
			AppContext context,
			IEmployeeRepository tRepo,
			IMapper mapper,
			IConfiguration configuration)
			: base(context, tRepo, mapper)
		{
			repo = tRepo;
			_configuration = configuration;
		}

		[HttpPost]
		public async Task<ActionResult> SignUp(SignUpViewModel model)
		{
			Employee employee = _mapper.Map<Employee>(model);
			await repo.CreateUserAsync(employee, model.Password);
			return Ok("Create employee successfully.");
		}
	}
}
