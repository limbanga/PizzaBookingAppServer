using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class ProductController : GenericController<Product>
	{
		public ProductController (
			AppContext context,
			IProductRepository tRepo, 
			IMapper mapper)
			: base(context, tRepo, mapper)
		{ }
	}
}
