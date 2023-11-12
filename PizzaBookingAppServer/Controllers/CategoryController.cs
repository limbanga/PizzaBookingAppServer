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

        [HttpGet("{alias}")]
        public async Task<ActionResult<Category>> GetCategoryByAlias(string alias)
        {
            var result = await _repo.GetByAliasAsync(alias);
            if (result is null)
            {
                return NotFound();
            }
            else
            {
                return result;
            }
        }
    }
}
