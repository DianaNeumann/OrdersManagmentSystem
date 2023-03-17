using Application.Dto.Providers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Providers;
using static Application.Contracts.Providers.Commands.CreateProvider;

namespace Presentation.WebApi.Controllers.Providers;

[ApiController]
[Route("api/[controller]")]
public class ProvidersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProvidersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("CreateProvider")]
    public async Task<ActionResult<ProviderDto>> CreatePlayerAsync([FromBody] CreateProviderModel model)
    {
        var command = new Command(model.Name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Provider);
    }
}