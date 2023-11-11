using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PizzaBookingAppClient.Exceptions;
using PizzaBookingAppClient.Providers;
using PizzaBookingShared.ViewModel;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

namespace PizzaBookingAppClient.Services
{
    public interface IAuthService
    {
        Task<TokenPairRespone> RegisterAsync(RegisterViewModel model);
        Task<TokenPairRespone> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<string> GetClaimValue(string key);
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;

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
            AuthenticationState temp = await _authenticationStateProvider.GetAuthenticationStateAsync();
            Claim? claim = temp.User.FindFirst(key);

            if (claim is null)
            {
                throw new Exception("Claim key doesn't exists.");
            }

            return claim.Value;
        }

        public async Task<TokenPairRespone> LoginAsync(LoginViewModel model)
        {
            var respone = await _httpClient.PostAsJsonAsync<LoginViewModel>("/User/Login", model);
            if (respone is null)
            {
                throw new Exception();
            }

            if (respone.StatusCode == HttpStatusCode.Unauthorized)
            {
                string errorMessage = await respone.Content.ReadAsStringAsync();
                throw new AppException(errorMessage);
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            TokenPairRespone? token = await respone.Content.ReadFromJsonAsync<TokenPairRespone>();
            if (token is null)
            {
                throw new Exception();
            }
			
            await _localStorageService.SetItemAsync<TokenPairRespone>("authToken", token);
            ((CustomAuthProvider)_authenticationStateProvider).NotifyAuthState();

			return token;
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((CustomAuthProvider)_authenticationStateProvider).NotifyAuthState();
        }

        public async Task<TokenPairRespone> RegisterAsync(RegisterViewModel model)
        {
            var respone = await _httpClient.PostAsJsonAsync<RegisterViewModel>("/User/Register", model);

            if (respone is null)
            {
                throw new Exception();    
            }

            if (respone.StatusCode == HttpStatusCode.BadRequest)
            {
                string errorMessage = await respone.Content.ReadAsStringAsync();
                throw new AppException(errorMessage);
            }

            if (!respone.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            TokenPairRespone? token = await respone.Content.ReadFromJsonAsync<TokenPairRespone>();
            if (token is null)
            {
                throw new Exception();
            }

            return token;
        }
    }
}
