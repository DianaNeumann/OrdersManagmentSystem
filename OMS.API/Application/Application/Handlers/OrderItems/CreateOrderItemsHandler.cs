using Application.Abstractions.DataAccess;
using Application.Exceptions;
using Application.Mapping.OrderItems;
using Application.Mapping.Orders;
using Domain.OrderItems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.OrderItems.Commands.CreateOrderItem;

namespace Application.Handlers.OrderItems;

public class CreateOrderItemsHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateOrderItemsHandler(IDatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id.Equals(request.OrderId), cancellationToken);

        if (order == null)
            throw new NotFoundException($"entity not found");

        var orderItem = new OrderItem(order, request.Name, request.Quantity, request.Unit);
        _context.Orderitems.Add(orderItem);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(orderItem.AsDto());
    }
}