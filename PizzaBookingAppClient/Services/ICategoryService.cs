using PizzaBookingAppClient.Pages.Admin;
using PizzaBookingViewModel;

namespace PizzaBookingAppClient.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
        Task CreateAsync(CategoryViewModel model);

    }
}