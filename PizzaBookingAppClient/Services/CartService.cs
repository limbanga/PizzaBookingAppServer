using Blazored.LocalStorage;
using PizzaBookingShared.Entities;
using static MudBlazor.Colors;

namespace PizzaBookingAppClient.Services
{
    public interface ICartService
    {
        Task<List<OrderLine>> GetAsync();
        Task Add(OrderLine orderLine);
        Task Remove(int productId);
        Task<int> CountAsync();
        double PreviewTotalPrice(List<OrderLine> orderLines);
        Task SaveCart(List<OrderLine> orderLines);

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

 
		public async Task<int> CountAsync()
		{
            var cart = await GetAsync();
			return cart.Count();
		}

        public double PreviewTotalPrice(List<OrderLine> orderLines)
        {

            double total = 0;
            foreach (var orderLine in orderLines)
            {
                if (orderLine.Product is not null)
                {
                    total += orderLine.Product.Price * orderLine.Quantity;
                }
            }

            return  total;
        }

        public async Task SaveCart(List<OrderLine> orderLines)
        {
            List<OrderLine> cart = new();
            foreach (var orderLine in orderLines)
            {
                cart.Add(new OrderLine
                {
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity,
                });
            }

            await _localStorageService.SetItemAsync<List<OrderLine>>("cart", cart);
        }
    }
}
