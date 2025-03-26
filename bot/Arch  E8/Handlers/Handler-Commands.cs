using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using Rezet.Logging;




namespace Rezet.Handlers {
    public class CommandsHandlers {
        public static async Task Activate(DiscordShardedClient Rezet) {
            await SyncSlash(Rezet);
            await SyncPrefix(Rezet);
        }
        private static async Task SyncPrefix(DiscordShardedClient ShardedRezet) {
            var prefix = ShardedRezet.UseCommandsNextAsync(
                new CommandsNextConfiguration {
                    StringPrefixes = [ "r." ],
                    CaseSensitive = false,
                    EnableDms = false,
                    EnableMentionPrefix = true
                });


            foreach (var p in await prefix) {
                p.Value.RegisterCommands<PrefixSystemCommands>();
            }


            
            RezetLogs.PrefixCommandsConnect();
            await Task.CompletedTask;
        }
        private static async Task SyncSlash(DiscordShardedClient ShardedRezet) {
            var slash = await ShardedRezet.UseSlashCommandsAsync();


            foreach (var s in slash.Values) {
                s.RegisterCommands<PartnershipCommands>();
                s.RegisterCommands<CommunityCommands>();
                s.RegisterCommands<RolesCommands>();
                s.RegisterCommands<ChatCommands>();
                s.RegisterCommands<RezetSystems>();
            }


            RezetLogs.SlashCommandsConnect();
            await Task.CompletedTask;
        }
    }
}