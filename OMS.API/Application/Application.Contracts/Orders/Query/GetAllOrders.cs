using Application.Dto.Orders;
using MediatR;

namespace Application.Contracts.Orders.Query;

public class GetAllOrders
{
    public record Query : IRequest<Response>;
    public record Response(IEnumerable<OrderDto> Orders);
}