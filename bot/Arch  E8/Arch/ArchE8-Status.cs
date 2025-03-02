// Configurações sobre o status do client.

// Status com detecção automática:
// - Online: ping abaixo de 100ms.
// - Idle: ping acima de 100ms, apresentando falhas leves em serviços automáticos.
// - Do not disturb: Apresentando falhas graves em todos os serviços.
// - Invisible: offline, atualizando ou em manutenção.


//                   Playing action! [ 0 - 50 / 20ms ]
//                      Shard number <-|    |    |-> Ping da shard atual
//        Quantidade de servers na shard <- |




using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;



namespace Rezet.Status {
    public class DiscordStatus {
        public static readonly TimeSpan StatusUpdateInterval = TimeSpan.FromSeconds(20);
        public static async Task StatusReady(DiscordShardedClient client) {
            foreach (var shard in client.ShardClients.Values) {
                shard.Ready += UpdateStatus;
            }
            await Task.CompletedTask;
        }



        private static async Task UpdateStatus(DiscordClient client, ReadyEventArgs e) {
            while (true) {
                var activity = new DiscordActivity($"action! [ {client.ShardId} - {client.Guilds.Count} / {client.Ping}ms ]", ActivityType.Playing);
                if (client.Ping > 200) {
                    await client.UpdateStatusAsync(activity, UserStatus.DoNotDisturb);
                } else if (client.Ping > 100) {
                    await client.UpdateStatusAsync(activity, UserStatus.Idle);
                } else {
                    await client.UpdateStatusAsync(activity, UserStatus.Online);
                }
                await Task.Delay(StatusUpdateInterval);
            }
        }
    }
}