using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HubitatBot;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
// Add HubitatBotService to HostApplicationBuilder.
builder.Services.AddHostedService<HubitatBotService>();
using IHost host = builder.Build();

// Ask the service provider for the configuration abstraction.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

// Start application.
await host.RunAsync();
