using PizzaBookingAppClient.Pages.Admin;
using PizzaBookingViewModel;

namespace PizzaBookingAppClient.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
        Task CreateAsync(CategoryViewModel model);
        Task UpdateAsync(CategoryViewModel model);
        Task DeleteAsync(int Id);
    }
}