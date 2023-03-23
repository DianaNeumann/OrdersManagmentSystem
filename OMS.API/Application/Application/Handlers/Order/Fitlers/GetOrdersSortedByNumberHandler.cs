using Application.Services.Interfaces;
using MediatR;
using static Application.Contracts.Orders.Query.GetOrdersSortedByNumber;

namespace Application.Handlers.Order.Fitlers;

public class GetOrdersSortedByNumberHandler : IRequestHandler<Query, Response>
{
    private readonly IOrdersFilterService _ordersFilterService;

    public GetOrdersSortedByNumberHandler(IOrdersFilterService ordersFilterService)
    {
        _ordersFilterService = ordersFilterService;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var orders = _ordersFilterService.GetOrdersSortedByNumber();
        return new Response(orders);
    }
}