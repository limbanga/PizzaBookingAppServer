using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

		[HttpPost]
		public async Task<ActionResult<LoginRespone>> Login(LoginViewModel model)
		{
			const int TOKEN_LIFE_TIME_MINUTE = 60 * 24; // 1 day

			Employee? employee = await repo.LoginAsync(model.LoginName, model.Password);
            
			if (employee is null)
            {
				return new LoginRespone();
            }

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSetting:Key")!);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim("id", employee.Id.ToString()),
				new Claim("email", employee.LoginName),
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(TOKEN_LIFE_TIME_MINUTE),
				Issuer = _configuration.GetValue<string>("JwtSetting:Issuer"),
				Audience = _configuration.GetValue<string>("JwtSetting:Audience"),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var stoken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(stoken);

			return new LoginRespone() { AccessToken = token };
		}
	}
}
