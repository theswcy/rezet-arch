using DSharpPlus;
using DSharpPlus.EventArgs;
using Rezet.Logging;
using Rezet.Events.SystemEvents;




namespace Rezet.Handlers {
    public static class EventsHandler {
        public static async Task SyncEvents(DiscordShardedClient client) {



            // ========== GUILD BASIC ACTIONS.
            client.GuildCreated += async (client, args) => {
                await Task.Run(async () => {
                    try {
                        await AddGuildOnHerrscher.Update(client, args);
                    } catch (Exception ex) {
                        RezetLogs.HandlerOperation(
                            "GUILD CREATE",
                            $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                        );
                    }
                });
            };



            RezetLogs.EventsCommandsConnect();
            await Task.CompletedTask;
        }
    }
}