using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PizzaBookingAppClient.Exceptions;
using PizzaBookingAppClient.Providers;
using PizzaBookingViewModel;
using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;

namespace PizzaBookingAppClient.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

		public AuthService(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorageService)
		{
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
			_localStorageService = localStorageService;
		}

		public async Task<string> GetClaimValue(string key)
		{
			var temp = await _authenticationStateProvider.GetAuthenticationStateAsync();
            Claim? claim = temp.User.FindFirst(key);

            if (claim == null)
            {
                throw new AppException("Claim key doesn't exists.");
            }

            return claim.Value;
		}

		public async Task<bool> LoginAsync(LoginViewModel model)
        {
			var respone = await _httpClient.PostAsJsonAsync<LoginViewModel>("/Employee/Login", model);
			
            if (respone == null || !respone.IsSuccessStatusCode)
			{
				throw new ConnectException();
			}

			LoginRespone? result = await respone.Content.ReadFromJsonAsync<LoginRespone>();
			await _localStorageService.SetItemAsync<string>("jwt_access", result!.AccessToken!);
			((CustomAuthProvider)_authenticationStateProvider).NotifyAuthState();

            return result != null;
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

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync("jwt_access");
            ((CustomAuthProvider)_authenticationStateProvider).NotifyAuthState();
        }
    }
}
