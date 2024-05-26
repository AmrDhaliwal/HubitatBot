using System.ComponentModel;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.SlashCommands;
using DSharpPlus.Entities;
namespace HubitatBot;

public class PingCommand
{
    [Command("ping")]
    [Description("Slash command to test bot response time.")]
    [DSharpPlus.Commands.Trees.Metadata.AllowedProcessors(typeof(SlashCommandProcessor))]
    [SlashCommandTypes(DiscordApplicationCommandType.SlashCommand)]
    public static ValueTask ExecuteAsync(CommandContext context) => context.RespondAsync($"Pong! Latency is {context.Client.Ping}ms.");
}
