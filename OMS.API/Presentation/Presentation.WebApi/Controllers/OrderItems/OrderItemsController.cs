using Application.Dto.OrderItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.OrderItem;
using static Application.Contracts.OrderItems.Commands.CreateOrderItem;

namespace Presentation.WebApi.Controllers.OrderItems;

[ApiController]
[Route("api/[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("CreateOrderItem")]
    public async Task<ActionResult<OrderItemDto>> CreateOrderItemAsync([FromBody] CreateOrderItemModel model)
    {
        var command = new Command(model.OrderId, model.Name, model.Quantity, model.Unit); 
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.OrderItem);
    }
}