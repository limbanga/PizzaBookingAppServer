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
		// Employee
		modelBuilder.Entity<Employee>()
			.HasIndex(e => e.LoginName)
			.IsUnique();
		modelBuilder.Entity<Employee>()
			.HasIndex(e => e.Email)
			.IsUnique();
		modelBuilder.Entity<Employee>()
			.HasIndex(e => e.PhoneNumber)
			.IsUnique();

	}

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is TimeRecord && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow; // current datetime

            if (entity.State == EntityState.Added)
            {
                ((TimeRecord)entity.Entity).CreatedAt = now;
            }
            ((TimeRecord)entity.Entity).UpdatedAt = now;
        }
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
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
