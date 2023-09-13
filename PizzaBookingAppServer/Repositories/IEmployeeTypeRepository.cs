﻿using PizzaBookingAppServer.Entities;

namespace PizzaBookingAppServer.Repositories
{
	public interface IEmployeeTypeRepository : IGenericRepository<EmployeeType>
	{
		Task<EmployeeType?> FindByNameAsync(string name);
	}
}