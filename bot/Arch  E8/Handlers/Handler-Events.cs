using DSharpPlus;
using DSharpPlus.EventArgs;
using Rezet.Logging;




namespace Rezet.Handlers {
    public static class EventsHandler {
        public static async Task SetupEvents(DiscordShardedClient client) {
            // client.ComponentInteractionCreated
            RezetLogs.EventsCommandsConnect();
            await Task.CompletedTask;
        }
    }
}