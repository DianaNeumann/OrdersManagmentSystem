using Application.Abstractions.DataAccess;
using Application.Mapping.Providers;
using MediatR;
using static Application.Contracts.Providers.Query.GetAllProviders;

namespace Application.Handlers.Providers;

public class GetAllProvidersHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllProvidersHandler(IDatabaseContext context)
    {
        _context = context;
    }


    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        return new Response(_context.Providers.Select(p => p.AsDto()));
    }
}