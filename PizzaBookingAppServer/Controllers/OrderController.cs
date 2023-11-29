using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingShared.Entities;
using PizzaBookingShared.Repositories;
using PizzaBookingShared;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using PizzaBookingShared.ViewModel;
using PizzaBookingAppServer.AppExceptions;
using System.Collections;

namespace PizzaBookingShared.Controllers
{
    [ApiController, Authorize(Roles = "admin")]
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

        [AllowAnonymous]
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

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Pay(PaymentViewModel model)
        {
            // kiểm tra nhận được tiền chưa từ đúng khác hàng chưa.

            // cập nhập trạng thái đơn hàng
            var order = await _repo.GetAsync(model.OrderId);

            if (order is null)
            {
                return BadRequest("Order id doesn't exist.");
            }

            order.State = "On the way";

            await _repo.UpdateAsync(order);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeStatus(ChangeStatusViewModel model)
        {
            // cập nhập trạng thái đơn hàng
            var order = await _repo.GetAsync(model.OrderId);

            if (order is null)
            {
                return BadRequest("Order id doesn't exist.");
            }

            order.State = model.State;

            await _repo.UpdateAsync(order);
            return Ok(order);
        }


        [HttpGet("{year}/{month?}")]
        public async Task<ActionResult<IEnumerable<DataPointViewModel>>> ReportSale(int year, int? month = null)
        {
            try
            {
                var report = await _repo.ReportSaleAsync(year, month);
                var data = report.ToArray();
                if (month is null)
                {
                    var monthList = new List<DataPointViewModel>
                    {
                        new DataPointViewModel(){Key="Jan", Value=data[0]},
                        new DataPointViewModel(){Key="Feb", Value=data[1]},
                        new DataPointViewModel(){Key="Mar", Value=data[2]},
                        new DataPointViewModel(){Key="Apr", Value=data[3]},
                        new DataPointViewModel(){Key="May", Value=data[4]},
                        new DataPointViewModel(){Key="Jun", Value=data[5]},
                        new DataPointViewModel(){Key="Jul", Value=data[6]},
                        new DataPointViewModel(){Key="Aug", Value=data[7]},
                        new DataPointViewModel(){Key="Sep", Value=data[8]},
                        new DataPointViewModel(){Key="Oct", Value=data[9]},
                        new DataPointViewModel(){Key="Nov", Value=data[10]},
                        new DataPointViewModel(){Key="Dec", Value=data[11]},
                    };
                    return monthList;
                }
                var dayList = new List<DataPointViewModel>(31);
                for (int i = 0; i < data.Length; i++)
                {
                    dayList.Add(
                        new DataPointViewModel { Key = (i + 1).ToString(), Value = data[i] }
                        );
                }
                return dayList;
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [NonAction]
        public override Task<ActionResult> Update(Order model)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [AllowAnonymous]
        public override Task<ActionResult<Order>> Get(int id)
        {
            return base.Get(id);
        }

        public override Task<ActionResult<List<Order>>> GetAll()
        {
            return base.GetAll();
        }
    }
}
