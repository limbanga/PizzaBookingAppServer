using Blazored.LocalStorage;
using PizzaBookingShared.Entities;

namespace PizzaBookingAppClient.Services
{
    public interface ICartService
    {
        Task<List<OrderLine>> Get();
        Task Add(OrderLine orderLine);
        Task Remove(int productId);
        Task CheckOut();
    }

    public class CartService : ICartService
    {
        ILocalStorageService _storage;
        public CartService(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public async Task<List<OrderLine>> Get()
        {
            var cart = await _storage.GetItemAsync<List<OrderLine>>("cart");
            if (cart == null) 
            {
                cart = new List<OrderLine>();
            }
            return cart;
        }

        public async Task Add(OrderLine orderLine)
        {
            var cart = await Get();

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

            await _storage.SetItemAsync<List<OrderLine>>("cart", cart);
        }

        public async Task Remove(int productId)
        {
            var cart = await Get();
            cart.RemoveAll(o => o.ProductId == productId);
            await _storage.SetItemAsync<List<OrderLine>>("cart", cart);
        }

        public Task CheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
