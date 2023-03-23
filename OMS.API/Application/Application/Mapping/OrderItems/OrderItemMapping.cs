using Application.Dto.OrderItems;
using Domain.OrderItems;

namespace Application.Mapping.OrderItems;

public static class OrderItemMapping
{
    public static OrderItemDto AsDto(this OrderItem orderItem)
        => new OrderItemDto(
            orderItem.Id,
            orderItem.Order.Id,
            orderItem.Name,
            orderItem.Quantity,
            orderItem.Unit);
}