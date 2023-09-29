using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;

namespace PizzaBookingShared.Controllers
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
