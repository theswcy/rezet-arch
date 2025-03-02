using System.Text.Json;
using DSharpPlus;
using Rezet.HerrscherSearch;
using Rezet.Logging;




#pragma warning disable CS8604
namespace Rezet {
    // ========== REZET ARCH ENGINE 8.
    class ArchE8 {
        // ========== IGNITES:
        public static DiscordShardedClient? RezetRazor;
        public static HerrscherServices? HerrscherRazor;



        public static async Task EngineStart() {
            // ========== GET THE TOKEN:
            try {
                RezetLogs.EngineStart("Arch 1.0.0");
                var configPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "obj", "config.json");
                var configJson = await File.ReadAllTextAsync(configPath);
                var config = JsonSerializer.Deserialize<Config>(configJson);




                // ========== CLIENT BUILDER:
                var rzt = new DiscordConfiguration {
                    Token = config?.Token,
                    TokenType = TokenType.Bot,
                    ShardCount = 1, // NOT FINISHED!
                    Intents = 
                        DiscordIntents.Guilds |
                        DiscordIntents.GuildBans | 
                        DiscordIntents.GuildIntegrations |
                        DiscordIntents.GuildMembers |
                        DiscordIntents.GuildMessages |
                        DiscordIntents.GuildMessageTyping |
                        DiscordIntents.GuildPresences |
                        DiscordIntents.MessageContents,
                    ReconnectIndefinitely = true,
                    GatewayCompressionLevel = GatewayCompressionLevel.None,
                    MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Error,
                };
                RezetRazor = new DiscordShardedClient(rzt);



                // ========== HERRSCHER CONNECT;
                HerrscherRazor = new HerrscherServices(config?.Keydb, "extension");



                // ========== START!
                await RezetRazor.StartAsync();
                await Handlers.CommandsHandler.SetupSlashCommands(RezetRazor);
                await Handlers.CommandsHandler.SetupPrefixCommands(RezetRazor);
                await Handlers.EventsHandler.SetupEvents(RezetRazor);
                await Status.DiscordStatus.StatusReady(RezetRazor);
                await AOCore.ShardsSockets.SetupSocketsEvents(RezetRazor);
                RezetLogs.FinishedBuild();
                await Task.Delay(-1);
            } catch (Exception ex) {
                RezetLogs.ErrorBuild(ex.Message);
            }
        }
    }
    class Config { public string? Token { get; set; } public string? Keydb { get; set; } }
}