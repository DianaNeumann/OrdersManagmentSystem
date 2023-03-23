using Application.Services.Interfaces;
using MediatR;
using static Application.Contracts.Orders.Query.GetOrdersByDateRange;

namespace Application.Handlers.Order.Fitlers;

public class GetOrdersByDateRangeHandler : IRequestHandler<Query, Response>
{
    private readonly IOrdersFilterService _ordersFilterService;

    public GetOrdersByDateRangeHandler(IOrdersFilterService ordersFilterService)
    {
        _ordersFilterService = ordersFilterService;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var orders = _ordersFilterService.GetOrderByDateRange(request.Start, request.End);
        return new Response(orders);
    }
}