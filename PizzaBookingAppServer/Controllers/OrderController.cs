using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
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
