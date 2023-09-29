using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;

namespace PizzaBookingShared.Controllers
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
