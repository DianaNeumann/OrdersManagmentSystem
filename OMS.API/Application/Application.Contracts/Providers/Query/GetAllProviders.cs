using Application.Dto.Providers;
using MediatR;

namespace Application.Contracts.Providers.Query;

public class GetAllProviders
{
    public record Query : IRequest<Response>;
    public record Response(IEnumerable<ProviderDto> Providers);
}