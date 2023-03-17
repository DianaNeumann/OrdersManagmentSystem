using Application.Abstractions.DataAccess;
using Application.Mapping.Providers;
using Domain.Providers;
using MediatR;
using static Application.Contracts.Providers.Commands.CreateProvider;

namespace Application.Handlers.Providers;

public class CreateProviderHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateProviderHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var provider = new Provider(request.Name);
        _context.Providers.Add(provider);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(provider.AsDto());
    }
}