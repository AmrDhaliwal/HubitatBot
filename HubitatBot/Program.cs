using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HubitatBot;
using HubitatBot.Hub;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
// Add HubitatBotService to HostApplicationBuilder.
builder.Services.AddHostedService<HubitatBotService>();
builder.Services.AddHubServices();
using IHost host = builder.Build();

// Ask the service provider for the configuration abstraction.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
IHttpClientFactory client =
    host.Services.GetRequiredService<IHttpClientFactory>();
var hub = new HubitatHub(client, "http://192.168.1.69", "f474ebc6-9140-4845-be24-dd5272b2b09e", 8);

var response = await hub.GetDevices();
Console.WriteLine(response.Length);
Console.WriteLine(response);
// Start application.
await host.RunAsync();
