using SimpleShop.Domain.Orders;

namespace SimpleShop.Infrastructure.Persistence.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}