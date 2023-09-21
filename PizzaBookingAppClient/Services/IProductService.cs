using PizzaBookingViewModel;

namespace PizzaBookingAppClient.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();

        Task CreateAsync(ProductViewModel productViewModel);
        Task<string> UploadProductImage(MultipartFormDataContent content);
    }
}