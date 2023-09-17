using PizzaBookingViewModel;

namespace PizzaBookingAppClient.Services
{
    public interface IAuthService
    {
        Task<LoginRespone> LoginAsync(LoginViewModel model);
        Task<BaseRespone> SignUpAsync(SignUpViewModel model);
    }
}