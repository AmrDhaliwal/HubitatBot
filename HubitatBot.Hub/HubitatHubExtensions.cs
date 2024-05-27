using Microsoft.Extensions.DependencyInjection;

namespace HubitatBot.Hub;
public static class HubitatHubServiceCollection
{
    public static void AddHubServices(this IServiceCollection services)
    {
        services.AddHttpClient();
    }
}