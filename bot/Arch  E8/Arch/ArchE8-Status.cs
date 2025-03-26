using DSharpPlus;
using DSharpPlus.Entities;
using Rezet.Logging;



namespace Rezet.Status {
    public class UṕdateStatus {
        public static async Task Start(DiscordShardedClient Client) {
            Client.Ready += async (client, args) => {
                await Task.Run(async () => {
                    try {
                        while (true) {
                            foreach (var shard in Client.ShardClients.Values) {
                                var activity = new DiscordActivity($"{shard.Ping}ms [{shard.Guilds.Count} - {shard.ShardId}]", ActivityType.Playing);
                                var clientStatus = UserStatus.Online;
                                if (shard.Ping >= 100) {
                                    clientStatus = UserStatus.DoNotDisturb;
                                } else if (shard.Ping >= 50) {
                                    clientStatus = UserStatus.Idle;
                                }
                                await shard.UpdateStatusAsync(activity, clientStatus);
                                await Task.Delay(30000);
                            }
                        }
                    } catch (Exception ex) {
                        RezetLogs.UpdateStatusOperation(
                            $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                        );
                    }
                });
            };
            await Task.CompletedTask;
        }
    }
}