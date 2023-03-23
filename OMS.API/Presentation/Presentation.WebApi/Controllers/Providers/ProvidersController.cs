using Application.Dto.Providers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Providers;
using static Application.Contracts.Providers.Commands.CreateProvider;
using static Application.Contracts.Providers.Query.GetAllProviders;

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

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("CreateProvider")]
    public async Task<ActionResult<ProviderDto>> CreateProviderAsync([FromBody] CreateProviderModel model)
    {
        var command = new Command(model.Name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Provider);
    }
    
    [HttpGet("GetAllProviders")]
    public async Task<ActionResult<IEnumerable<ProviderDto>>> GetAllProviders()
    {
        var query = new Query();
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.Providers);
    }
}