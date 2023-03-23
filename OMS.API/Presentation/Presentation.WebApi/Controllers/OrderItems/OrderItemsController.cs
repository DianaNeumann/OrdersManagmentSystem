using Application.Contracts.OrderItems.Commands;
using Application.Dto.OrderItems;
using FluentValidation;
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
    public async Task<ActionResult<OrderItemDto>> CreateOrderItemAsync(
        [FromBody] CreateOrderItemModel model,
        [FromServices] IValidator<CreateOrderItem.Command> validator)
    {
        var command = new Command(model.OrderId, model.Name, model.Quantity, model.Unit); 
     
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.OrderItem);
    }
    
    [HttpDelete("DeleteOrderItem/{id}")]
    public async Task<ActionResult> DeleteOrderItemAsync(int id)
    {
        var command = new DeleteOrderItem.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }
    
    [HttpPut("UpdateOrderItem")]
    public async Task<ActionResult<OrderItemDto>> UpdateOrderItemAsync(
        [FromBody] UpdateOrderItemModel model,
        [FromServices] IValidator<UpdateOrderItem.Command> validator
        )
    {
        var command = new UpdateOrderItem.Command(model.Id, model.OrderId, model.Name, model.Quantity, model.Unit);        
        
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.OrderItem);
    }
}