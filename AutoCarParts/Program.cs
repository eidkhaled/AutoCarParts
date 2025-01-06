using AutoCarParts.BusinessLogic.CategoryService;
using AutoCarParts.BusinessLogic.CustomerService;
using AutoCarParts.BusinessLogic.InventoryService;
using AutoCarParts.BusinessLogic.ManufacturesService;
using AutoCarParts.BusinessLogic.OrderDtos;
using AutoCarParts.BusinessLogic.PartService;
using AutoCarParts.BusinessLogic.RepositoryPattern;
using AutoCarParts.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPartService,PartService>();
builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
builder.Services.AddScoped<IManufacturesRepo,ManufacturesRepo>();
builder.Services.AddScoped<IInventory,InventoryRepo>();
builder.Services.AddScoped<IOrderRepo,OrderRepo>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped(typeof(IRepositoryCrud<>), typeof(RepositoryCrud<>));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var JwtOptionts = builder.Configuration.GetSection("JwtSettings").Get<Jwt>();
builder.Services.AddSingleton(JwtOptionts);
builder.Services.AddAuthentication(
    options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
                                   ).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer =JwtOptionts.Issuer,
        ValidAudience = JwtOptionts.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(JwtOptionts.SecretKey))
    };
});
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
app.UseAuthorization();

app.MapControllers();

app.Run();
