using ECommerceTask.Api.Configuration;
using ECommerceTask.Domain.Contracts;
using ECommerceTask.Domain.Services;
using ECommerceTask.Infrastructure;
using ECommerceTask.Infrastructure.Contracts;
using ECommerceTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddControllers();

var dbConfig = builder.Configuration.GetSection(nameof(DBConfiguration)).Get<DBConfiguration>();
builder.Services.AddDbContext<OrderContext>(options => options.UseSqlServer(dbConfig.ConnectionString, sql => { }));


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
