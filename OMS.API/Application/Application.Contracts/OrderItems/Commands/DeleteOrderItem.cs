using MediatR;

namespace Application.Contracts.OrderItems.Commands;

public class DeleteOrderItem
{
    public record struct Command(int Id) : IRequest<Response>;

    public record struct Response;
}