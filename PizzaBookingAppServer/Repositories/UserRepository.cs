using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaBookingShared.Repositories
{
    public interface IUserRepository
    {
        Task RegisterAsync(User model);
        Task<User> LoginAsync(string loginName, string password);
        string GetAccessTokenAsync(User model);
    }

    public class UserRepository : IUserRepository
	{
        const int TOKEN_LIFE_TIME_MINUTE = 60 * 24; // 1 day

        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AppContext _context;
        private readonly IConfiguration _configuration;


        public UserRepository(
            AppContext context, 
            IConfiguration configuration
            )
        {
            _passwordHasher = new PasswordHasher<User>();
            _configuration = configuration;
            _context = context;
        }

        public string GetAccessTokenAsync(User model)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", model.Id.ToString()),
                new Claim("email", model.LoginName),
                new Claim("phoneNumber", model.PhoneNumber),
                new Claim("role", model.Role?? ""),
            };

            return WriteToken(claims);
        }

        public async Task<User> LoginAsync(string loginName, string password)
        {
            User? user = await _context.User
                .Where(u => u.LoginName.Equals(loginName))
                .FirstOrDefaultAsync();

            if (user is null)
            {
                throw new AppException("User does't exist.");
            }

            if (user.Locked)
            {
                throw new AppException("This account is locked.");
            }

            var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password);
            if (verifyResult != PasswordVerificationResult.Success)
            {
                throw new AppException("Password is incorrect.");
            }

            return user;
        }

        public async Task RegisterAsync(User model)
        {
            bool isEmailExist = _context.User
                .Where(u => u.LoginName.Equals(model.LoginName))
                .Any();
            // check
            if (isEmailExist)
            {
                throw new AppException("Email is exists.");
            }

            bool isPhoneNumberExist = _context.User 
                .Where(u => u.PhoneNumber.Equals(model.PhoneNumber))
                .Any();

            if (isPhoneNumberExist) {
                throw new AppException("PhoneNumber is exists.");
            }

            model.HashedPassword = _passwordHasher.HashPassword(model, model.HashedPassword);

            _context.Add(model);
            await _context.SaveChangesAsync();
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
