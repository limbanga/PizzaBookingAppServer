using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Controllers;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;

namespace PizzaBookingAppServer.Controllers
{
    [ApiController]
    public class OrderLineController : GenericController<OrderLine>
    {
        private readonly IOrderLineRepository _repo;
        public OrderLineController(
            AppContext context,
            IOrderLineRepository tRepo,
            IMapper mapper
            )
            : base(context, tRepo, mapper)
        {
            _repo = tRepo;
        }

        [HttpGet("{orderId}")]
        public async Task<IEnumerable<OrderLine>> GetByOrderId(int orderId)
        {
            var list = await _repo.GetByOrderIdAsync(orderId);
            return list;
        }
    }
}
