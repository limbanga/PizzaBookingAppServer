using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public abstract class GenericController<T> : ControllerBase where T : class
	{
		private readonly AppContext _context;
		private readonly IGenericRepository<T> _repo;
		protected readonly IMapper _mapper;
		protected GenericController(
			AppContext context,
			IGenericRepository<T> tRepo,
			IMapper mapper)
		{
			_context = context;
			this._repo = tRepo;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public virtual async Task<ActionResult<T>> Get(int id)
		{
			var model = await _repo.FindByIdAsync(id);
			if (model is null)
			{
				return NotFound();
			}
			return model;
		}

		[HttpGet]
		public virtual async Task<ActionResult<List<T>>> GetAll()
		{
			return await _repo.GetAllAsync();
		}

		[HttpPost]
		public virtual async Task<ActionResult> Create(T model)
		{
			try
			{
				T t = await _repo.CreateAsync(model);
				return Ok(t);
			}
			catch (Exception e)
			{
				return Problem($"Can't create {typeof(T).Name}: {e.Message}");
			}
		}

		[HttpPut]
		public virtual async Task<ActionResult> Update(T model)
		{
			try
			{
				await _repo.UpdateAsync(model);
				return Ok();
			}
			catch (Exception)
			{

				return Problem($"Can't update {typeof(T).Name}");
			}
		}

		[HttpDelete("{id}")]
		public virtual async Task<ActionResult> Delete(int id)
		{
			try
			{
				await _repo.DeleteAsync(id);
				return Ok();
			}
			catch (Exception)
			{
				return Problem($"Can't delete {typeof(T).Name}");
			}
		}
	}
}
