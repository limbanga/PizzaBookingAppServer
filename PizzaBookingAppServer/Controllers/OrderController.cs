using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;

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

		[NonAction]
        public override Task<ActionResult> Update(Order model)
        {
            return base.Update(model);
        }

        public override Task<ActionResult<Order>> Create(Order model)
        {
			// get user id if exist
            return base.Create(model);
        }

		[HttpPost]
		public async Task<ActionResult> Pay(int id) 
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
    }
}
