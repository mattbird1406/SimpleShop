using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Features.Orders.CreateOrder;
using SimpleShop.Infrastructure.Persistence;
using SimpleShop.Infrastructure.Persistence.EF.Repositories;
using SimpleShop.Api.GraphQL.Mutations;
using SimpleShop.Api.GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger support

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR with the configuration action
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderHandler).Assembly);
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Register GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<OrderMutations>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// Map GraphQL endpoint
app.MapGraphQL(); // This will expose /graphql by default

app.Run();