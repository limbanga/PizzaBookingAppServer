using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.AppExceptions;
using PizzaBookingShared.Entities;

namespace PizzaBookingShared.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<double>> ReportSaleAsync(int year, int? month = null);
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(AppContext context) 
			: base(context)
		{ }

        public override async Task<List<Order>> GetAllAsync()
        {
            var list =  await _context.Order
                .Include(o=> o.Customer)
                .Include(o => o.OrderLines)
                .ToListAsync();

            return list;
        }

        public async Task<IEnumerable<double>> ReportSaleAsync(int year, int? month = null)
        {
            if (month == null && month < 0 || month > 12)
            {
                throw new RequestException("Invalid month.");
            }
            var query = _context.Order
                .Where(o => o.UpdatedAt.Year == year)
                .AsQueryable();

            if (month == null) // by year
            {
                var groupByMonth = await query
                    .Include(o => o.OrderLines)
                    .GroupBy(o => o.UpdatedAt.Month)
                    .ToListAsync();

                double[] salesInMonth = Enumerable.Repeat(0.0, 12).ToArray(); ;

                foreach (var orders in groupByMonth)
                {
                    double sale = 0;
                    foreach (var order in orders)
                    {
                        foreach (var orderLine in order.OrderLines!)
                        {
                            orderLine.Product = await _context.Product.FindAsync(orderLine.ProductId);
                            sale += orderLine.Quantity * orderLine.Product!.Price;
                        }
                    }
                    salesInMonth[orders.Key] = sale;
                }
                return salesInMonth;
            }
            // by month

            query = query.Where(o => o.UpdatedAt.Month == month);
            int numDaysInMonth = DateTime.DaysInMonth(year, (int)month);
            double[] salesInDay = Enumerable.Repeat(0.0, numDaysInMonth).ToArray();

            var groupByDay = await query
                   .Include(o => o.OrderLines)
                   .GroupBy(o => o.UpdatedAt.Day)
                   .ToListAsync();
            foreach (var orders in groupByDay)
            {
                double sale = 0;
                foreach (var order in orders)
                {
                    foreach (var orderLine in order.OrderLines!)
                    {
                        orderLine.Product = await _context.Product.FindAsync(orderLine.ProductId);
                        sale += orderLine.Quantity * orderLine.Product!.Price;
                    }
                }
                salesInDay[orders.Key] = sale;
            }

            return salesInDay;
        }
    }
}
