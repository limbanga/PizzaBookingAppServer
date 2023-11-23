using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Repositories;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;

namespace PizzaBookingAppServer.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppSettingRepository _repo;
        private readonly IUserRepository _userRepository;

        public AppController(
            IAppSettingRepository repo,
            IUserRepository userRepository)
        {
            _repo = repo;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<AppSetting>> Get()
        {
            return await _repo.GetAsync();
        }

        [HttpPut]
        public async Task<ActionResult<AppSetting>> Update(AppSetting model)
        {
            return await _repo.UpdateAsync(model);
        }

        [HttpGet]
        public async Task<ActionResult> Initialize()
        {
            // tạo admin
            var admin = new User
            {
                LoginName = "admin@gmail.com",
                HashedPassword = "Letmein12#",
                FirstName = "fadmin",
                LastName="ladmin",
                PhoneNumber = "1234567890",
                Role = "admin"
            };
            await _userRepository.RegisterAsync(admin);

            // tạo appseting

            var appSetting = new AppSetting
            {
                AllowAnonymousLogin = true,
                Dense = true,
                Bordered=false,
                Striped=true,
                Hover=true,
            };

            await _repo.CreateAsync(appSetting);

            return Ok("Initialize success");
        }
    }
}
