using Domain.Orders;

namespace Domain.OrderItems;

public class OrderItem
{
    public OrderItem()
    {
        
    }
    public OrderItem(Order order, string name, decimal quantity, string unit)
    {
        Order = order;
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    public OrderItem(int id, Order order, string name, decimal quantity, string unit)
    {
        Id = id;
        Order = order;
        Name = name;
        Quantity = quantity;
        Unit = unit;
    }

    public int Id { get; set; }
    public virtual Order Order { get; set; }
    public string Name { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
}