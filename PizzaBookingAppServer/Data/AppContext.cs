using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBookingShared.Entities;

public class AppContext : DbContext
{
    public AppContext (DbContextOptions<AppContext> options)
        : base(options)
    { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		// 
		modelBuilder.Entity<User>()
			.HasIndex(u => u.LoginName)
			.IsUnique();
		modelBuilder.Entity<User>()
			.HasIndex(u => u.PhoneNumber)
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

    public DbSet<PizzaBookingShared.Entities.Category> Category { get; set; } = default!;
	public DbSet<PizzaBookingShared.Entities.User> User { get; set; } = default!;
	public DbSet<PizzaBookingShared.Entities.ImageProduct> ImageProduct { get; set; } = default!;
	public DbSet<PizzaBookingShared.Entities.Order> Order { get; set; } = default!;
	public DbSet<PizzaBookingShared.Entities.OrderLine> OrderLine { get; set; } = default!;
	public DbSet<PizzaBookingShared.Entities.Product> Product { get; set; } = default!;
}
