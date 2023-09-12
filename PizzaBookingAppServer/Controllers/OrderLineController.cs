using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class OrderLineController : GenericController<OrderLine>
	{
		public OrderLineController(
			AppContext context, 
			IOrderLineRepository tRepo,
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }

	}
}
