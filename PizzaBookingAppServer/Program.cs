using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PizzaBookingAppServer.Helpers;
using PizzaBookingAppServer.Repositories;
using PizzaBookingShared.Helpers;
using PizzaBookingShared.Repositories;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppContext") ??
		throw new InvalidOperationException("Connection string 'AppContext' not found.")));
builder.Services.AddAutoMapper(typeof(Program));


// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderLineRepository, OrderLineRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IUploader, Uploader>();

builder.Services.AddTransient<IAppSettingRepository, AppSettingRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(x =>
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidIssuer = builder.Configuration.GetValue<string>("JwtSetting:Issuer"),
		ValidAudience = builder.Configuration.GetValue<string>("JwtSetting:Audience"),
		IssuerSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSetting:Key")!)),
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ClockSkew = TimeSpan.Zero
	};
});

builder.Services.AddAuthorization();

const string DEVELOPMENT_POLICY = "DEVELOPMENT_POLICY";

builder.Services.AddCors(options =>
{
	options.AddPolicy(DEVELOPMENT_POLICY, p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
	
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors(DEVELOPMENT_POLICY);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
	
app.MapControllers();

app.Run();
