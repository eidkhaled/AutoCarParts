using AutoCarParts.BusinessLogic.CategoryService;
using AutoCarParts.BusinessLogic.ManufacturesService;
using AutoCarParts.BusinessLogic.PartService;
using AutoCarParts.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPartService,PartService>();
builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
builder.Services.AddScoped<IManufacturesRepo,ManufacturesRepo>();

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
