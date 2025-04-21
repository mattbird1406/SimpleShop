public class OrderItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public OrderItem() { }

    public OrderItem(string productName, int quantity, decimal unitPrice)
    {
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}