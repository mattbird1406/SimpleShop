using MediatR;
using SimpleShop.Domain.Orders;
using SimpleShop.Infrastructure.Persistence;

namespace SimpleShop.Application.Features.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = request.Items.Select(i =>
                new OrderItem(i.ProductName, i.Quantity, i.UnitPrice)).ToList();

            var order = new Order(request.CustomerName, items);

            var orderId = await _repository.CreateOrderAsync(order, cancellationToken);

            return orderId;
        }
    }
}