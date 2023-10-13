using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Helpers;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;

namespace PizzaBookingShared.Controllers
{
	[ApiController]
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
        public async Task<List<Product>> GetAllWithCategory()
        {
            return await _productRepo.GetAllWithCategoryAsync();
        }

        [HttpGet("{categoryId}")]
        public async Task<Int32> CountByCategory(int categoryId)
        {
            int result = await _productRepo.CountByCategory(categoryId);
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
