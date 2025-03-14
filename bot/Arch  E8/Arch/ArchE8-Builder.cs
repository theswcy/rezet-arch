using System.Text.Json;
using DSharpPlus;
using DSharpPlus.Entities;
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
                    ShardCount = 1,
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
                var activity = new DiscordActivity("action!", ActivityType.Playing);
                await RezetRazor.StartAsync();
                await Handlers.CommandsHandlers.Activate(RezetRazor);
                await Handlers.EventsHandler.Activate(RezetRazor);
                await RezetRazor.UpdateStatusAsync(activity, UserStatus.DoNotDisturb);
                await AOCore.ShardsSockets.Activate(RezetRazor);
                RezetLogs.FinishedBuild(RezetRazor.CurrentUser.Username);


                await Task.Delay(-1);
            } catch (Exception ex) {
                RezetLogs.ErrorBuild($"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
    class Config { public string? Token { get; set; } public string? Keydb { get; set; } }
}