using DSharpPlus;
using DSharpPlus.EventArgs;
using Rezet.Logging;




namespace Rezet.Handlers {
    public static class EventsHandler {
        public static async Task Activate(DiscordShardedClient Rezet) {
            await SyncEvents(Rezet);
        }
        private static async Task SyncEvents(DiscordShardedClient client) {
            // client.ComponentInteractionCreated
            RezetLogs.EventsCommandsConnect();
            await Task.CompletedTask;
        }
    }
}