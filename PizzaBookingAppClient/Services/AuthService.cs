using PizzaBookingAppClient.Exceptions;
using PizzaBookingViewModel;
using System.Net;
using System.Net.Http.Json;

namespace PizzaBookingAppClient.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginRespone> LoginAsync(LoginViewModel model)
        {
			var respone = await _httpClient.PostAsJsonAsync<LoginViewModel>("/Employee/Login", model);
			
            if (respone == null || !respone.IsSuccessStatusCode)
			{
				throw new ConnectException();
			}

			LoginRespone? result = await respone.Content.ReadFromJsonAsync<LoginRespone>();

            return result ?? new LoginRespone();
		}

        public async Task<BaseRespone> SignUpAsync(SignUpViewModel model)
        {
            var respone = await _httpClient.PostAsJsonAsync<SignUpViewModel>("/create-admin", model);
            
            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }

            return new BaseRespone();
        }
    }
}
