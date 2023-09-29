using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;

namespace PizzaBookingShared.Controllers
{
	[ApiController]
	public class OrderController : GenericController<Order>
	{
		public OrderController(
			AppContext context,
			IOrderRepository tRepo,
			IMapper mapper)
			: base(context, tRepo, mapper)
		{ }
	}
}
