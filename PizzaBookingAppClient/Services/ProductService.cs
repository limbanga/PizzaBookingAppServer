using PizzaBookingAppClient.Exceptions;
using PizzaBookingViewModel;
using System.Net.Http.Json;

namespace PizzaBookingAppClient.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAsync(ProductViewModel model)
        {
            var respone = await _httpClient.PostAsJsonAsync<ProductViewModel>("/Product/Create", model);

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var respone = await _httpClient.GetAsync("/Product/GetAll");

            if (respone == null || !respone.IsSuccessStatusCode)
            {
                throw new ConnectException();
            }

            List<ProductViewModel>? result = await respone.Content.ReadFromJsonAsync<List<ProductViewModel>>();

            return result!;
        }

        public async Task<string> UploadProductImage(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("/Product/UploadProductImage/", content);
            var returnFileName = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Can't up load file.");
            }
            return returnFileName;
        }
    }
}
