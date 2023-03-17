using Application.Dto.Providers;
using Domain.Providers;

namespace Application.Mapping.Providers;

public static class ProviderMapping
{
    public static ProviderDto AsDto(this Provider provider)
        => new ProviderDto(provider.Id, provider.Name);
}