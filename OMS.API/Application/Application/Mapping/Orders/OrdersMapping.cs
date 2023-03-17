using Application.Dto.Orders;
using Domain.Orders;

namespace Application.Mapping.Orders;

public static class OrdersMapping
{
    public static OrderDto AsDto(this Order order)
        => new OrderDto(order.Id, order.Number, order.Date, order.Provider.Id);
}