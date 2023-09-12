using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class CategoryController : GenericController<Category>
	{
		public CategoryController(
			AppContext context, 
			ICategoryRepository tRepo,
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }
	}
}
