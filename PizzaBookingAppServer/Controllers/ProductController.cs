using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Helpers;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
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

        public override Task<ActionResult> Create(Product model)
        {
            return base.Create(model);
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
