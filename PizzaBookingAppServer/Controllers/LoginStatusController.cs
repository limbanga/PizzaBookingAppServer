using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.Entities;
using PizzaBookingAppServer.Repositories;

namespace PizzaBookingAppServer.Controllers
{
	[ApiController]
	public class LoginStatusController : GenericController<LoginStatus>
	{
		public LoginStatusController(
			AppContext context, 
			ILoginStatusRepository tRepo,
			IMapper mapper) 
			: base(context, tRepo, mapper)
		{ }

	}
}
