using Application.Dto.OrderItems;
using Application.Dto.Orders;
using MediatR;

namespace Application.Contracts.OrderItems.Commands;

public class UpdateOrderItem
{
    public record struct Command(int Id, int OrderId, string Name, decimal Quantity, string Unit) : IRequest<Response>;

    public record struct Response(OrderItemDto OrderItem);
}