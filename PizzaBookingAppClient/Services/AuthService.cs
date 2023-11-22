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
        Task RegisterAsync(RegisterViewModel model);
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

            if (respone.IsSuccessStatusCode)
            {
                var token = await respone.Content.ReadFromJsonAsync<TokenPairRespone>();

                await _localStorageService.SetItemAsync<TokenPairRespone>("authToken", token!);
                ((CustomAuthProvider)_authenticationStateProvider).NotifyAuthState();

                return token!;
            }

            string errorMessage = await respone.Content.ReadAsStringAsync();

            throw new AppException(errorMessage);
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((CustomAuthProvider)_authenticationStateProvider).NotifyAuthState();
        }

        public async Task RegisterAsync(RegisterViewModel model)
        {
            var respone = await _httpClient.PostAsJsonAsync<RegisterViewModel>("/User/Register", model);

            if (respone.IsSuccessStatusCode)
            {
                return;
            }

            string errorMessage = await respone.Content.ReadAsStringAsync();
            throw new AppException(errorMessage);
        }
    }
}
