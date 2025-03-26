using DSharpPlus;
using DSharpPlus.EventArgs;
using Rezet.Logging;



namespace Rezet.AOCore {
    public class ShardsSockets {
        public static async Task Activate(DiscordShardedClient Rezet) {
            Rezet.SocketOpened += async (client, args) => {
                await Task.Run(async () => {
                    await OnSocketOpened(client, args);
                });
            };
            Rezet.SocketClosed += async (client, args) => {
                await Task.Run(async () => {
                    await OnSocketClosed(client, args);
                });
            };
            Rezet.SocketErrored += async (client, args) => {
                await Task.Run(async () => {
                    await OnSocketErrored(client, args);
                });
            };
            await Task.CompletedTask;
        }
        private static async Task OnSocketOpened(DiscordClient client, EventArgs e) {
            RezetLogs.SocketOpened(client.ShardId);
            await Task.CompletedTask;
        }


        private static async Task OnSocketClosed(DiscordClient client, SocketCloseEventArgs e) {
            int retryCount = 0;
            while (retryCount < 15) {
                RezetLogs.SocketClosed(e.CloseMessage, client.ShardId);
                try {
                    await client.ReconnectAsync();
                } catch (Exception ex) {
                    RezetLogs.SocketClosedReconnect($"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}", client.ShardId);
                    retryCount++;
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
            RezetLogs.SocketClosedError(e.CloseMessage, client.ShardId);
        }


        private static async Task OnSocketErrored(DiscordClient client, SocketErrorEventArgs e) {
            RezetLogs.SocketErrored($"- {e.Exception.GetType()}\n- {e.Exception.Message}\n{e.Exception.StackTrace}", client.ShardId);
            await Task.CompletedTask;
        }
    }
}