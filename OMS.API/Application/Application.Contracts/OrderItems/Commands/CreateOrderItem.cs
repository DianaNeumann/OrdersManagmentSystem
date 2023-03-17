using Domain.OrderItems;
using MediatR;

namespace Application.Contracts.OrderItems.Commands;

public class CreateOrderItem
{
    public record struct Command(
        int OrderId,
        string Name,
        decimal Quantity,
        string Unit) 
        : IRequest<Response>;

    public record struct Response(OrderItem OrderItem);
}