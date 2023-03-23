using Application.Dto.Orders;
using MediatR;

namespace Application.Contracts.Orders.Commands;

public class UpdateOrder
{
    public record struct Command(int Id, string Number, DateTime Date, int ProviderId) : IRequest<Response>;

    public record struct Response(OrderDto Order);
}