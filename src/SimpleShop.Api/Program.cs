using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Features.Orders.CreateOrder;
using SimpleShop.Infrastructure.Persistence;
using SimpleShop.Infrastructure.Persistence.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Add this line to enable Swagger

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR with the configuration action
builder.Services.AddMediatR(cfg =>
{
    // Register services from the assembly containing CreateOrderHandler
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderHandler).Assembly);
});
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
