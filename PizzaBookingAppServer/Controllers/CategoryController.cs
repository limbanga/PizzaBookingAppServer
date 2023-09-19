using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;
using PizzaBookingViewModel;

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

        public override Task<ActionResult> Create(Category model)
        {
            return base.Create(model);
        }

        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        public override Task<ActionResult<Category>> Get(int id)
        {
            return base.Get(id);
        }

        public override Task<ActionResult<List<Category>>> GetAll()
        {
            return base.GetAll();
        }

        public override Task<ActionResult> Update(Category model)
        {
            return base.Update(model);
        }
    }
}
