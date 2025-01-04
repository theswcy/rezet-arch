using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;




namespace RezetBuilder.Handlers {
    public static class CommandsHandler {
        public static async Task SetupPrefixCommands(DiscordShardedClient client) {
            foreach (var shard in client.ShardClients.Values) {
                var commands = shard.UseCommandsNext(new CommandsNextConfiguration {
                    StringPrefixes = [ "r." ],
                    CaseSensitive = false,
                    EnableDms = false,
                    EnableMentionPrefix = true
                });
            }
            await Task.CompletedTask;
        }
        public static async Task SetupSlashCommands(DiscordShardedClient client) {
            foreach (var shard in client.ShardClients.Values) {
                Console.WriteLine($"shard: {shard.ShardId}");
                var command = shard.UseSlashCommands();
                command.RegisterCommands<CommandTask>();
            }
            await Task.CompletedTask;
        }
    }



    public class CommandTask : ApplicationCommandModule {
        [SlashCommand("task", "task")]
        public static async Task C(InteractionContext ctx) {
            await ctx.CreateResponseAsync("nice!");
        }
    }
}