using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingAppServer.Helpers;
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
        private readonly IMailService _mailService;

        public UserController(
            IUserRepository repo,
            IConfiguration configuration,
            IMapper mapper,
            IMailService mailService)
        {
            _repo = repo;
            _configuration = configuration;
            _mapper = mapper;
            _mailService = mailService;
        }

        [HttpPost]
		public async Task<ActionResult<TokenPairRespone>> Login(LoginViewModel model)
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
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                User userModel = _mapper.Map<User>(model);
                var activeToken = _repo.GenerateRandomToken(32);
                userModel.ActiveAccountToken = activeToken;
                await _repo.RegisterAsync(userModel);

                // send active account link
                //_mailService.SendMail(
                //    new string[] { model.LoginName },
                //    "Active your account",
                //    $"<a href='https://localhost:7266/active={activeToken}'>" +
                //    $"Click here to active your account.</a>",
                //    isBodyHtml: true);

                return Ok("Register success");
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

        [HttpGet("/active={activeToken}")]
        public async Task<ActionResult> ActiveAccount(string activeToken)
        {
            try
            {
                await _repo.ActiveAccountAsync(activeToken);
                return Ok("Your account has just been actived");
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

        [HttpPost, Authorize]
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

        [HttpPost]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {

            try
            {
                // generate new password here
                string newPassword = "Letmein123$";
				string email = model.Email;
				var resetPasswordToken =  await _repo.GenerateResetPasswordToken(email, newPassword);

                _mailService.SendMail(
                    new string[] { email },
                    "Reset password",
                    $"Your new password is: { newPassword } <br/>" +
                    $"<a href='https://localhost:7266/reset={resetPasswordToken}'>" +
                    $"Click here to active your account.</a>", 
                    isBodyHtml: true);

                return Ok("Email was send!");
            }
            catch (RequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("/reset={resetPasswordToken}")]
        public async Task<ActionResult> ActivePassword(string resetPasswordToken)
        {
            try
            {
                await _repo.ActiveNewPasswordAsync(resetPasswordToken);
                return Ok("New password is take effect now!");
            }
            catch (RequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Authorize(Roles ="admin")]
        public async Task<ActionResult<List<User>>> GetAll()
        {

            try
            {
                var list = await _repo.GetAllAsync();
                return list;
            }
            catch (RequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
