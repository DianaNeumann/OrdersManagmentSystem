using MediatR;

namespace Application.Contracts.Orders.Commands;

public class DeleteOrder
{
    public record struct Command(int Id) : IRequest<Response>;

    public record struct Response;
}