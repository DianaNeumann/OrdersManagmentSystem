using Application.Dto.Orders;
using MediatR;

namespace Application.Contracts.Orders.Query;

public class GetOrdersByDateRange
{
    public record Query(DateTime Start, DateTime End) : IRequest<Response>;
    public record Response(IEnumerable<OrderDto> Orders);
}