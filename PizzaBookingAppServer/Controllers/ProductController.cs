using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Helpers;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;
using Microsoft.AspNetCore.Authorization;
using PizzaBookingAppServer.Helpers;

namespace PizzaBookingShared.Controllers
{
	[ApiController, Authorize(Roles = "admin")]
	public class ProductController : GenericController<Product>
	{
        private readonly IProductRepository _productRepo;
        private readonly IUploader _uploader;

        public ProductController(
            AppContext context,
            IProductRepository tRepo,
            IMapper mapper,
            IProductRepository productRepo,
            IUploader uploader)
            : base(context, tRepo, mapper)
        {
            _productRepo = productRepo;
            _uploader = uploader;
        }

        [HttpGet, AllowAnonymous]
        public override async Task<ActionResult<List<Product>>> GetAll()
        {
            return await base.GetAll();
        }

        [AllowAnonymous]
		public override Task<ActionResult<Product>> Get(int id)
		{
			return base.Get(id);
		}

		[HttpGet("{alias}"), AllowAnonymous]
		public async Task<ActionResult<Product>> GetByAlias(string alias)
		{
			var model = await _productRepo.GetByAliasAsync(alias);
			if (model is null)
			{
				return NotFound();
			}
			return model!;
		}

		[HttpGet, AllowAnonymous]
		public async Task<List<Product>> Fillter(
            string? name,
            [FromQuery(Name ="cate")] string? categoryAlias
            )
		{
			return await _productRepo.FillterAsync(name, categoryAlias);
		}

        [HttpGet, AllowAnonymous]
        public async Task<List<Product>> GetAllWithCategory()
        {
            return await _productRepo.GetAllWithCategoryAsync();
        }

        [HttpGet("{categoryId}"),
        AllowAnonymous]
        public async Task<Int32> CountByCategory(int categoryId)
        {
            int result = await _productRepo.CountByCategory(categoryId);
            return result;
        }

        [HttpGet("{categoryAlias}"), AllowAnonymous]
        public async Task<List<Product>> GetAllByCategoryAlias(string categoryAlias)
        {
            var result = await _productRepo.GetAllByCategoryAliasAsync(categoryAlias);
            return result;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<string>> Upload(IFormFile file)
        {
            const long maxSize = 20 * 1024 * 1024;
            if (file.Length > maxSize)
            {
                return BadRequest("File too large (> 20Mb).");
            }

            try
            {
                string newFileName = await _uploader.UploadTo(file, "products");
                return newFileName;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

		public override Task<ActionResult<Product>> Create(Product model)
		{
            model.Alias = StringHelper.ConvertToUrlSlug(model.Name);
			return base.Create(model);
		}

		public override Task<ActionResult> Update(Product model)
		{
			model.Alias = StringHelper.ConvertToUrlSlug(model.Name);
			return base.Update(model);
		}
	}
}
