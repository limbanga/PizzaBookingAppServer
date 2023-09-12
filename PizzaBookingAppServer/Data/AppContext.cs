using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBookingAppServer.Entities;

public class AppContext : DbContext
{
    public AppContext (DbContextOptions<AppContext> options)
        : base(options)
    { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<PizzaBookingAppServer.Entities.Category> Category { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.Customer> Customer { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.Employee> Employee { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.EmployeePermission> EmployeePermission { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.EmployeeType> EmployeeType { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.HasPermission> HasPermission { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.ImageProduct> ImageProduct { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.IncludePermisson> IncludePermisson { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.LoginStatus> LoginStatus { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.Order> Order { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.OrderLine> OrderLine { get; set; } = default!;
	public DbSet<PizzaBookingAppServer.Entities.Product> Product { get; set; } = default!;
}
