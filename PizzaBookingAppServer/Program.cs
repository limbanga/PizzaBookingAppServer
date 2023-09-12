using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaBookingAppServer.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppContext") ?? throw new InvalidOperationException("Connection string 'AppContext' not found.")));
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddTransient<ILoginStatusRepository, LoginStatusRepository>();
builder.Services.AddTransient<IEmployeePermissonRepository, EmployeePermissonRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IEmployeeTypeRepository, EmployeeTypeRepository>();
builder.Services.AddTransient<IImageProductRepository, ImageProductRepository>();
builder.Services.AddTransient<IHasPermissionRepository, HasPermissionRepository>();
builder.Services.AddTransient<IIncludePermissionRepository, IncludePermissionRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
