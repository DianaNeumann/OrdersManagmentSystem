using Application.Abstractions.DataAccess;
using Application.Mapping.Orders;
using MediatR;
using static Application.Contracts.Orders.Commands.UpdateOrder;

namespace Application.Handlers.Order;

public class UpdateOrderhandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;


    public UpdateOrderhandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {

        var order = new Domain.Orders.Order(
            request.Id,
            request.Number,
            request.Date,
            _context.Providers.First(p => p.Id.Equals(request.ProviderId)));

        _context.Orders.Update(order);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(order.AsDto());
    }
}