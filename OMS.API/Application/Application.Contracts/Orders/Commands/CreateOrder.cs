using Application.Dto.Orders;
using MediatR;

namespace Application.Contracts.Orders.Commands;

public class CreateOrder
{
    public record struct Command(string Number, DateTime Date, int ProviderId) : IRequest<Response>;

    public record struct Response(OrderDto Order);
}