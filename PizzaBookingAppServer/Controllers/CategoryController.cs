using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;
using PizzaBookingAppServer.Helpers;

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

        public override Task<ActionResult<Category>> Create(Category model)
        {
            model.Alias = StringHelper.ConvertToUrlSlug(model.Name);
            return base.Create(model);
        }

        public override Task<ActionResult> Update(Category model)
        {
            model.Alias = StringHelper.ConvertToUrlSlug(model.Name);
            return base.Update(model);
        }
    }
}
