using Application.Abstractions.DataAccess;
using MediatR;
using static Application.Contracts.OrderItems.Commands.DeleteOrderItem;

namespace Application.Handlers.OrderItems;

public class DeleteOrderItemHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public DeleteOrderItemHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var item = _context.Orderitems.First(o => o.Id.Equals(request.Id));
        _context.Orderitems.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
        return new Response();
    }
}