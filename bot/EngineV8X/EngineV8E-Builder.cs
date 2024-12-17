using System.Text.Json;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.CommandsNext;




namespace RezetBuilder
{
    // ========== REZET ENGINE V8 ELITE.
    class EngineV8E
    {
        // ========== IGNITES:
        public static DiscordShardedClient? RezetRazor;
        public static CommandsNextExtension? CommandsRazor;
        // public static HerrscherService? HerrscherRazor;
        private static Timer? _connectionCheckTimer;




        public static async Task EngineStart()
        {
            // ========== GET THE TOKEN:
            var configPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "obj", "config.json");
            var configJson = await File.ReadAllTextAsync(configPath);
            var config = JsonSerializer.Deserialize<Config>(configJson);




            // ========== CLIENT BUILDER:
            var rzt = new DiscordConfiguration
            {
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

        }
    }
    class Config { public string? Token { get; set; } public string? Keydb { get; set; } }
}