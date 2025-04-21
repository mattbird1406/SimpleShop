using SimpleShop.Domain.Orders;

namespace SimpleShop.Infrastructure.Persistence
{
    public interface IOrderRepository
    {
        Task<Guid> CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    }
}