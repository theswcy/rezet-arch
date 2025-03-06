using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using Rezet.Logging;




namespace Rezet.Handlers {
    public class CommandsHandlers {
        public static async Task Activate(DiscordShardedClient Rezet) {
            await SyncPrefix(Rezet);
            await SyncSlash(Rezet);
        }
        private static async Task SyncPrefix(DiscordShardedClient ShardedRezet) {
            var prefix = ShardedRezet.UseCommandsNextAsync(new CommandsNextConfiguration {
                StringPrefixes = [ "r." ],
                CaseSensitive = false,
                EnableDms = false,
                EnableMentionPrefix = true
            });


            
            RezetLogs.PrefixCommandsConnect();
            await Task.CompletedTask;
        }
        private static async Task SyncSlash(DiscordShardedClient ShardedRezet) {
            var slash = await ShardedRezet.UseSlashCommandsAsync();



            slash.RegisterCommands<PartnershipCommands>();
            slash.RegisterCommands<CommunityCommands>();
            slash.RegisterCommands<RolesCommands>();
            slash.RegisterCommands<ChatCommands>();
            slash.RegisterCommands<RezetSystems>();



            RezetLogs.SlashCommandsConnect();
            await Task.CompletedTask;
        }
    }
}