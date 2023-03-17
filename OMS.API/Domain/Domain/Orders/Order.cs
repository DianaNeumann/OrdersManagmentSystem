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
    }

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public virtual Provider Provider { get; set; }
    
}