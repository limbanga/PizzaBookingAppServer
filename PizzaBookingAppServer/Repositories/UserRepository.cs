using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PizzaBookingShared.Repositories
{
    public interface IUserRepository
    {
        Task RegisterAsync(User model);
        Task ActiveAccountAsync(string activeToken);
        Task<User> LoginAsync(string loginName, string password);
        string GetAccessTokenAsync(User model);
        Task ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        Task<string> GenerateResetPasswordToken(string email, string newPassword);
        Task ActiveNewPasswordAsync(string resetPasswordToken);
        Task<List<User>> GetAllAsync();
        string GenerateRandomToken(int length);
    }

    public class UserRepository : IUserRepository
	{
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

        public async Task ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            User? user = await _context.User.FindAsync(userId);

            if (user is null)
            {
                throw new AppException("User does't exist.");
            }

            // Check password is correct
            var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, oldPassword);
            if (verifyResult != PasswordVerificationResult.Success)
            {
                throw new AppException("Old password is incorrect.");
            }

            user.HashedPassword = _passwordHasher.HashPassword(user, newPassword);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GenerateResetPasswordToken(string email, string newPassword)
        {
            var model = await _context.User
                        .Where(u => u.LoginName.Equals(email))
                        .FirstOrDefaultAsync();

            if (model is null)
            {
                throw new RequestException("Email doesn't exist.");
            }

            string randomToken = GenerateRandomToken();
            model.ResetPasswordToken = randomToken;
            model.NewPassword = newPassword;
            _context.User.Update(model);
            await _context.SaveChangesAsync();
            return randomToken;
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
                new Claim("lastName", model.LastName?? ""),
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
                throw new AppException("User doesn't exist.");
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

        private string WriteToken(
            List<Claim> claims,
            long tokenLifeTimeSecond = 60 * 60 * 24 // 1 day
            )
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtSetting:Key")!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(tokenLifeTimeSecond),
                Issuer = _configuration.GetValue<string>("JwtSetting:Issuer"),
                Audience = _configuration.GetValue<string>("JwtSetting:Audience"),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public string GenerateRandomToken(int length = 32)
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] tokenData = new byte[length];
                rng.GetBytes(tokenData);

                StringBuilder tokenBuilder = new StringBuilder();
                foreach (byte b in tokenData)
                {
                    tokenBuilder.Append($"{b:X2}");
                }

                return tokenBuilder.ToString();
            }
        }

        public async Task ActiveNewPasswordAsync(string resetPasswordToken)
        {
            var model = await _context.User
                .Where(u =>
                 u.ResetPasswordToken != null &&
                 u.ResetPasswordToken.Equals(resetPasswordToken))
                .FirstOrDefaultAsync();

            if (model is null)
            {
                throw new RequestException("resetPasswordToken does't exist.");
            }

            model.HashedPassword = _passwordHasher.HashPassword(model, model.NewPassword!);

            model.NewPassword = null;
            model.ResetPasswordToken = null;

            _context.User.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var list = await _context.User.ToListAsync();
            return list;        
        }

        public async Task ActiveAccountAsync(string activeToken)
        {
            var model = await _context.User
                            .Where(u =>
                             u.ActiveAccountToken != null &&
                             u.ActiveAccountToken.Equals(activeToken))
                            .FirstOrDefaultAsync();

            if (model is null)
            {
                throw new RequestException("activeToken does't exist.");
            }

            model.ActiveAccountToken = null;
            _context.User.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
