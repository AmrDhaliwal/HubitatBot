using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using DSharpPlus;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.SlashCommands;

namespace HubitatBot;

public sealed class HubitatBotService : IHostedService
{
    private readonly ILogger<HubitatBotService> _logger;
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly DiscordClient _discordClient;
    private readonly IConfiguration _config;
    private readonly IServiceProvider _serviceProvider;

    public HubitatBotService(ILogger<HubitatBotService> logger, IHostApplicationLifetime applicationLifetime, IConfiguration config, IServiceProvider serviceProvider)
    {
        this._logger = logger;
        this._applicationLifetime = applicationLifetime;
        this._config = config;
        this._serviceProvider = serviceProvider;
        this._discordClient = new(new()
        {
            Token = this._config.GetValue<string>("Bot:Token"),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All
        });
    }

    public async Task StartAsync(CancellationToken token)
    {
        // Register Discord commands to bot.
        Assembly currentAssembly = typeof(Program).Assembly;
        CommandsExtension extension = this._discordClient.UseCommands(new()
        {
            DebugGuildId = this._config.GetValue<ulong>("Bot:Debug_Guild_Id", 0),
            ServiceProvider = this._serviceProvider,
        });
        await extension.AddProcessorAsync(new SlashCommandProcessor());
        extension.AddCommands(currentAssembly, this._config.GetValue<ulong>("Bot:Debug_Guild_Id", 0));

        // Start Discord Bot connection.
        await _discordClient.ConnectAsync();
        this._logger.LogInformation("{Name} started successfully.", this.GetType().Name);
    }

    public async Task StopAsync(CancellationToken token)
    {
        await _discordClient.DisconnectAsync();
        // More cleanup possibly here
    }
}
