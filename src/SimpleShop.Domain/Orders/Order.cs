namespace SimpleShop.Domain.Orders;
public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public List<OrderItem> Items { get; private set; }

    // EF Core requires a parameterless constructor
    private Order() { }

    public Order(string customerName, List<OrderItem> items)
    {
        CustomerName = customerName;
        Items = items ?? new List<OrderItem>();
    }
}