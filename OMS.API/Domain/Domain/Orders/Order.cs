using Domain.OrderItems;
using Domain.Providers;

namespace Domain.Orders;

public class Order
{
    public Order()
    {
    }
    public Order(string number, DateTime date, Provider provider)
    {
        Number = number;
        Date = date;
        Provider = provider;
        OrderItems = new List<OrderItem>();
    }

    public Order(int id, string number, DateTime date, Provider provider)
    {
        Id = id;
        Number = number;
        Date = date;
        Provider = provider;
        OrderItems = new List<OrderItem>();
    }

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public virtual Provider Provider { get; set; }

    public virtual List<OrderItem> OrderItems { get; set; }

    public void AddOrderItem(OrderItem orderItem)
    {
        OrderItems.Add(orderItem);
    }
}