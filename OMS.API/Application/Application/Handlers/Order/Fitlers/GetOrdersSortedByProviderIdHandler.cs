using Application.Services.Interfaces;
using MediatR;
using static Application.Contracts.Orders.Query.GetOrdersSortedByProviderId;

namespace Application.Handlers.Order.Fitlers;

public class GetOrdersSortedByProviderIdHandler : IRequestHandler<Query, Response>
{
    private readonly IOrdersFilterService _ordersFilterService;

    public GetOrdersSortedByProviderIdHandler(IOrdersFilterService ordersFilterService)
    {
        _ordersFilterService = ordersFilterService;
    }
    

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var orders = _ordersFilterService.GetOrdersSortedByProvidrId();
        return new Response(orders);
    }
}