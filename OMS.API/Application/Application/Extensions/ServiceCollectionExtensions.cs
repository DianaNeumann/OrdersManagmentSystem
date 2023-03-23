using Application.Services.Implementations;
using Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(IAssemblyMarker));
        collection.AddScoped<IOrdersFilterService, OrdersFilterService>();
        return collection;
    }
}