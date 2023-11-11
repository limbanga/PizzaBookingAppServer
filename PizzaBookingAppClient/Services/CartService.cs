using Blazored.LocalStorage;
using PizzaBookingShared.Entities;

namespace PizzaBookingAppClient.Services
{
    public interface ICartService
    {
        Task<List<OrderLine>> GetAsync();
        Task Add(OrderLine orderLine);
        Task Remove(int productId);
        Task<int> CountAsync();
        Task CheckOut();
    }

    public class CartService : ICartService
    {
        ILocalStorageService _localStorageService;
        public CartService(ILocalStorageService storage)
        {
            _localStorageService = storage;
        }

        public async Task<List<OrderLine>> GetAsync()
        {
            var cart = await _localStorageService.GetItemAsync<List<OrderLine>>("cart");
            if (cart == null) 
            {
                cart = new List<OrderLine>();
            }
            return cart;
        }

        public async Task Add(OrderLine orderLine)
        {
            var cart = await GetAsync();

            var temp = cart.FirstOrDefault(o => o.ProductId == orderLine.ProductId);

            if (temp == null)
            {
                temp = orderLine;
                cart.Add(temp);
            }
            else
            {
                temp.Quantity = orderLine.Quantity;
            }

            await _localStorageService.SetItemAsync<List<OrderLine>>("cart", cart);
        }

        public async Task Remove(int productId)
        {
            var cart = await GetAsync();
            cart.RemoveAll(o => o.ProductId == productId);
            await _localStorageService.SetItemAsync<List<OrderLine>>("cart", cart);
        }

        public Task CheckOut()
        {
            throw new NotImplementedException();
        }

		public async Task<int> CountAsync()
		{
            var cart = await GetAsync();
			return cart.Count();
		}
	}
}
