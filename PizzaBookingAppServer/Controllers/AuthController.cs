using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingAppServer.Repositories;
using PizzaBookingShared.Repositories;
using PizzaBookingShared.ViewModel;

namespace PizzaBookingAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TokenPairRespone>> LoginAsync(LoginViewModel model)
        {
            try
            {
                string accessToken = await _authRepository.GetAccessTokenAsync(model.LoginName, model.Password);
                return new TokenPairRespone() { AccessToken = accessToken };
            }
            catch (AppException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
