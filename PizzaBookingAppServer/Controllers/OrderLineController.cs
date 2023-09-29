using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;

namespace PizzaBookingShared.Controllers
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
