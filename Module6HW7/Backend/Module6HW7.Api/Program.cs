using Module6HW7.Core;
using Microsoft.EntityFrameworkCore;
using Module6HW7.Core.Interfaces;
using Module6HW7.Infrastructure;
using Module6HW7.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EntityContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStore, ProductStore>();

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
