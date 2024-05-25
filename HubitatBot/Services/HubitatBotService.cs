using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using Microsoft.Extensions.Configuration;

namespace HubitatBot;

public sealed class HubitatBotService : IHostedService
{
    private readonly ILogger<HubitatBotService> _logger;
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly DiscordClient _discordClient;
    private readonly IConfiguration _config;

    public HubitatBotService(ILogger<HubitatBotService> logger, IHostApplicationLifetime applicationLifetime, IConfiguration config)
    {
        this._logger = logger;
        this._applicationLifetime = applicationLifetime;
        this._config = config;
        this._discordClient = new(new()
        {
            Token = config.GetValue<string>("Bot:Token"),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged
        });
    }

    public async Task StartAsync(CancellationToken token)
    {
        await _discordClient.ConnectAsync();
        // Other startup things here
        this._logger.LogInformation("{Name} started successfully.", this.GetType().Name);
    }

    public async Task StopAsync(CancellationToken token)
    {
        await _discordClient.DisconnectAsync();
        // More cleanup possibly here
    }
}
