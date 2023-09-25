using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PizzaBookingAppClient.Exceptions;
using PizzaBookingAppClient.Providers;
using PizzaBookingViewModel;
using System.Net.Http.Json;
using System.Reflection;

namespace PizzaBookingAppClient.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var respone = await _httpClient.GetAsync("/Category/GetAll");

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }

            List<CategoryViewModel>? result = await respone.Content.ReadFromJsonAsync<List<CategoryViewModel>>();

            return result!;
        }

        public async Task CreateAsync(CategoryViewModel model)
        {
            var respone = await _httpClient.PostAsJsonAsync<CategoryViewModel>("/Category/Create", model);

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }
        }

        public async Task UpdateAsync(CategoryViewModel model)
        {
            var respone = await _httpClient.PutAsJsonAsync<CategoryViewModel>("/Category/Update", model);

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }
        }

        public async Task DeleteAsync(int Id)
        {
            var respone = await _httpClient.DeleteAsync($"Category/Delete/{ Id }");

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }
        }

        public async Task<CategoryViewModel?> GetAsync(int Id)
        {
            var respone = await _httpClient.GetAsync($"Category/Get/{Id}");

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }

            CategoryViewModel? result = await respone.Content.ReadFromJsonAsync<CategoryViewModel?>();
            return result;
        }
    }
}
