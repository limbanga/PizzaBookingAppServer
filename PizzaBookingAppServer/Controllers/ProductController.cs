using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Helpers;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;
using Microsoft.AspNetCore.Authorization;

namespace PizzaBookingShared.Controllers
{
	[ApiController]
    [Authorize(Policy = "admin")]
	public class ProductController : GenericController<Product>
	{
        private readonly IProductRepository _productRepo;
        public ProductController(
            AppContext context,
            IProductRepository tRepo,
            IMapper mapper,
            IProductRepository productRepo)
            : base(context, tRepo, mapper)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public override async Task<ActionResult<List<Product>>> GetAll()
        {
            return await base.GetAll();
        }

        [AllowAnonymous]
		public override Task<ActionResult<Product>> Get(int id)
		{
			return base.Get(id);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<List<Product>> Fillter(
            string? name,
            [FromQuery(Name ="cate")] string? categoryAlias
            )
		{
			return await _productRepo.FillterAsync(name, categoryAlias);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<List<Product>> GetAllWithCategory()
        {
            return await _productRepo.GetAllWithCategoryAsync();
        }

        [HttpGet("{categoryId}")]
		[AllowAnonymous]
		public async Task<Int32> CountByCategory(int categoryId)
        {
            int result = await _productRepo.CountByCategory(categoryId);
            return result;
        }

        [HttpGet("{categoryAlias}")]
        [AllowAnonymous]
        public async Task<List<Product>> GetAllByCategoryAlias(string categoryAlias)
        {
            var result = await _productRepo.GetAllByCategoryAliasAsync(categoryAlias);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<string>> UploadProductImage(IFormFile file)
        {
            try
            {
                string newFileName = await Uploader.UploadTo(file, "products");
                return newFileName;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
