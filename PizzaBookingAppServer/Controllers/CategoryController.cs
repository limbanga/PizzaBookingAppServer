using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;
using PizzaBookingAppServer.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PizzaBookingShared.Controllers
{
    [ApiController, Authorize(Roles ="admin")]
     
    public class CategoryController : GenericController<Category>
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(
            AppContext context,
            ICategoryRepository tRepo,
            IMapper mapper)
            : base(context, tRepo, mapper)
        {
            _repo = tRepo;
        }

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

        [AllowAnonymous]
        public override Task<ActionResult<Category>> Get(int id)
        {
            return base.Get(id);
        }

        [AllowAnonymous]
        public override Task<ActionResult<List<Category>>> GetAll()
        {
            return base.GetAll();
        }

    }
}
