using Application.Dto.Providers;
using MediatR;

namespace Application.Contracts.Providers.Commands;

public class CreateProvider
{
    public record struct Command(string Name) : IRequest<Response>;

    public record struct Response(ProviderDto Provider);
}