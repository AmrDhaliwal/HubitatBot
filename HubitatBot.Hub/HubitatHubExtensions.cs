using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace HubitatBot.Hub;
public static class HubitatHubServiceCollection
{
    public static void AddHubServices(this IServiceCollection services, string host)
    {
        services.AddRefitClient<IMakerAPI>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(host));
    }
}
