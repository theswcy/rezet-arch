using DSharpPlus;
using DSharpPlus.EventArgs;
using Rezet.Logging;



namespace Rezet.AOCore {
    public class ShardsSockets {
        public static async Task SetupSocketsEvents(DiscordShardedClient client) {
            foreach(var shard in client.ShardClients.Values) {
                shard.SocketOpened += OnSocketOpened;
                shard.SocketClosed += OnSocketClosed;
                shard.SocketErrored += OnSocketErrored;
            }
            await Task.CompletedTask;
        }


        public static async Task OnSocketOpened(DiscordClient client, EventArgs e) {
            RezetLogs.SocketOpened(client.ShardId);
            await Task.CompletedTask;
        }


        public static async Task OnSocketClosed(DiscordClient client, SocketCloseEventArgs e) {
            int retryCount = 0;
            while (retryCount < 15) {
                RezetLogs.SocketClosed(e.CloseMessage, client.ShardId);
                try {
                    await client.ReconnectAsync();
                } catch (Exception ex) {
                    RezetLogs.SocketClosedReconnect(ex.Message, client.ShardId);
                    retryCount++;
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
            RezetLogs.SocketClosedError(e.CloseMessage, client.ShardId);
        }


        public static async Task OnSocketErrored(DiscordClient client, SocketErrorEventArgs e) {
            RezetLogs.SocketErrored(e.Exception.Message, client.ShardId);
            await Task.CompletedTask;
        }
    }
}