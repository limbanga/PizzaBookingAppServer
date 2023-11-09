using Microsoft.IdentityModel.Tokens;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaBookingAppServer.Repositories
{

    public interface IAuthRepository
    {
        Task<string> GetAccessTokenAsync(string userName, string password);
    }

    public class AuthRepository : IAuthRepository
    {
        const int TOKEN_LIFE_TIME_MINUTE = 60 * 24; // 1 day


        private readonly AppContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        public AuthRepository(
            AppContext context,
            IConfiguration configuration,
            IEmployeeRepository employeeRepository,
            ICustomerRepository customerRepository)
        {
            _context = context;
            _configuration = configuration;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public async Task<string> GetAccessTokenAsync(string userName, string password)
        {
            var employee = await _employeeRepository.LoginAsync(userName, password);
            if (employee != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", employee.Id.ToString()),
                    new Claim("email", employee.LoginName),
                    new Claim("role", employee.Role),
                };

                return WriteToken(claims);
            }

            var customer = await _customerRepository.LoginAsync(userName, password);
            if (customer != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", customer.Id.ToString()),
                    new Claim("email", customer.LoginName),
                };

                return WriteToken(claims);
            }

            return "";
        }

        private string WriteToken(List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSetting:Key")!);



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

            return token;
        }
    }
}
