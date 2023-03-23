using Application.Abstractions.DataAccess;
using Application.Dto.Orders;
using Application.Mapping.Orders;
using MediatR;
using static Application.Contracts.Orders.Query.GetAllOrders;

namespace Application.Handlers.Order;

public class GetAllOrdersHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllOrdersHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        return new Response(_context.Orders.Select(o => o.AsDto()));
    }
}