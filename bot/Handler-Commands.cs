using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;




namespace Rezet.Handlers {
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
                var command = shard.UseSlashCommands();

                //command.RegisterCommands<>();
            }
            await Task.CompletedTask;
        }
    }
}