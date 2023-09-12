using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class ImageProductController : GenericController<ImageProduct>
	{
		public ImageProductController(
			AppContext context,
			IImageProductRepository tRepo, 
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }
	}
}
