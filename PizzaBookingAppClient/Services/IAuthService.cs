using PizzaBookingViewModel;

namespace PizzaBookingAppClient.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginViewModel model);
        Task<BaseRespone> SignUpAsync(SignUpViewModel model);
        Task LogoutAsync();
        Task<string> GetClaimValue(string key);
    }
}