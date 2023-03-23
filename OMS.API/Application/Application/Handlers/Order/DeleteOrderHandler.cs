using Application.Abstractions.DataAccess;
using MediatR;
using static Application.Contracts.Orders.Commands.DeleteOrder;

namespace Application.Handlers.Order;

public class DeleteOrderHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public DeleteOrderHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var order = _context.Orders.First(o => o.Id.Equals(request.Id));
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
        return new Response();
    }
}