using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;
using System.Security.Claims;

namespace PizzaBookingShared.Controllers
{
	[ApiController]
	public class OrderController : GenericController<Order>
	{
		private readonly IOrderRepository _repo;
		public OrderController(
			AppContext context,
			IOrderRepository tRepo,
			IMapper mapper)
			: base(context, tRepo, mapper)
		{
			_repo = tRepo;
		}

		[HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllIncludeCustomer()
        {
            return await _repo.GetAllIncludeCustomerAsync();
        }

        public override Task<ActionResult<Order>> Create(Order model)
        {
			// get user id if exist
			var claimId = User.FindFirst("id");

            if (claimId is not null)
			{
				model.CustomerId = Convert.ToInt32(claimId.Value);
			}

            return base.Create(model);
        }

		[HttpPost]
		public async Task<ActionResult> Pay([FromBody] int id) 
		{
			// kiểm tra nhận được tiền chưa từ đúng khác hàng chưa.
			
			// cập nhập trạng thái đơn hàng
			var model = await _repo.GetAsync(id);

			if (model is null)
			{
				return BadRequest("Order id doesn't exist.");
			}

			model.State = "On the way";

			await _repo.UpdateAsync(model);
			return Ok(model);	
		}

        [NonAction]
        public override Task<ActionResult> Update(Order model)
        {
            return base.Update(model);
        }
    }
}
