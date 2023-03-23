using Application.Abstractions.DataAccess;
using Application.Exceptions;
using Application.Mapping.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Orders.Commands.CreateOrder;

namespace Application.Handlers.Order;

public class CreateOrderHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateOrderHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var provider = await _context.Providers
            .FirstOrDefaultAsync(p => p.Id.Equals(request.ProviderId), cancellationToken);

        if (provider == null)
            throw new NotFoundException($"entity not found");
        var order = new Domain.Orders.Order(request.Number, request.Date, provider);
        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(order.AsDto());
    }
}