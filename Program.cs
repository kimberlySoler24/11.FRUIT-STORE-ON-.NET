using Microsoft.EntityFrameworkCore;
using TiendaDeFrutas.Contracts;
using TiendaDeFrutas.Data;
using TiendaDeFrutas.Repository;
using TiendaDeFrutas.Services.Contracts;
using TiendaDeFrutas.Services.Contracts.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//create dependences of interfaces and 
builder.Services.AddScoped<IFruitService, FruitService>();
builder.Services.AddScoped<IFruitRepository, FruitRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


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
