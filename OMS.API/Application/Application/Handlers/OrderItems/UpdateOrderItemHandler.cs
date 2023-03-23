using Application.Abstractions.DataAccess;
using Application.Mapping.OrderItems;
using MediatR;
using static Application.Contracts.OrderItems.Commands.UpdateOrderItem;

namespace Application.Handlers.OrderItems;

public class UpdateOrderItemHandler  : IRequestHandler<Command, Response>
{    
    private readonly IDatabaseContext _context;

    public UpdateOrderItemHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var item = new Domain.OrderItems.OrderItem(
            request.Id,
            _context.Orders.First(o => o.Id.Equals(request.OrderId)),
            request.Name,
            request.Quantity,
            request.Unit);

        _context.Orderitems.Update(item);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(item.AsDto());
    }
}