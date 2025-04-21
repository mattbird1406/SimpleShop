using MediatR;

namespace SimpleShop.Application.Features.Orders.CreateOrder;

public record CreateOrderCommand(string CustomerName, List<CreateOrderItemDto> Items) 
    : IRequest<Guid>;

public record CreateOrderItemDto(string ProductName, int Quantity, decimal UnitPrice);