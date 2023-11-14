using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared.ViewModel;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaBookingShared.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
		private readonly IUserRepository _repo;
		private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserController(
            IUserRepository repo,
            IConfiguration configuration,
            IMapper mapper)
        {
            _repo = repo;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
		public async Task<ActionResult<TokenPairRespone>> LoginAsync(LoginViewModel model)
		{
			try
			{
                User user = await _repo.LoginAsync(model.LoginName, model.Password);
				string accessToken = _repo.GetAccessTokenAsync(user);

				return new TokenPairRespone
				{
					AccessToken = accessToken,
					RefreshToken = ""
				};
            }
            catch (AppException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
			{
				throw;
			}
		}

        [HttpPost]
        public async Task<ActionResult<TokenPairRespone>> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                User userModel = _mapper.Map<User>(model);

                await _repo.RegisterAsync(userModel);

                string accessToken = _repo.GetAccessTokenAsync(userModel);

                return new TokenPairRespone
                {
                    AccessToken = accessToken,
                    RefreshToken = ""
                };
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirstValue("id"));
            try
            {
                await _repo.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
                return Ok("Password has been changed.");
            }
            catch (AppException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
