using Application.Contracts.Orders.Commands;
using Application.Contracts.Orders.Query;
using Application.Dto.Orders;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Orders;

namespace Presentation.WebApi.Controllers.Orders;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("CreateOrder")]
    public async Task<ActionResult<OrderDto>> CreateOrderAsync(
        [FromBody] CreateOrderModel model,
        [FromServices] IValidator<CreateOrder.Command> validator)
    {
        var command = new CreateOrder.Command(model.Number, model.Date, model.ProviderId);
     
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Order);
    }
    
    [HttpDelete("DeleteOrder/{id}")]
    public async Task<ActionResult> DeleteOrderAsync(int id)
    {
        var command = new DeleteOrder.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }
    
    [HttpPut("UpdateOrder")]
    public async Task<ActionResult<OrderDto>> UpdateOrderAsync(UpdateOrderModel model)
    {
        var command = new UpdateOrder.Command(model.Id, model.Number, model.Date, model.ProviderId);
        
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Order);
    }
    
    [HttpGet("GetAllOrders")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrdersAsync()
    {
        var query = new GetAllOrders.Query();
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.Orders);
    }
    
    [HttpGet("GetOrdersSortedByNumber")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersSortedByNumberAsync()
    {
        var query = new GetOrdersSortedByNumber.Query();
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.Orders);
    }
    
    [HttpGet("GetOrdersSortedByProviderId")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersSortedByProviderIdAsync()
    {
        var query = new GetOrdersSortedByProviderId.Query();
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.Orders);
    }
    
    [HttpPost("GetOrdersByDateRange")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrdersByDataRangeAsync([FromBody] GetOrderByDateRangeModel model)
    {
        var query  = new GetOrdersByDateRange.Query(model.Start, model.End);
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.Orders);
    }
}