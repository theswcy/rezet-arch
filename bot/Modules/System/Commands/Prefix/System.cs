using System.Diagnostics;
using System.Reflection;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using MongoDB.Bson;



#pragma warning disable CS8602
namespace Rezet.PrefixCommands.SystemCommands {
    public class PrefixSys {
        public static async Task Informations(CommandContext ctx) {
            var proc = Process.GetCurrentProcess();
            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var fileSize = fileInfo.Length / 1024.0 / 1024.0;



            var MachineInformations = new DiscordEmbedBuilder() {
                Color = new DiscordColor("#7e67ff")
            };
            MachineInformations.WithAuthor(
                name: "Arch Engine 8",
                iconUrl: "https://cdn.discordapp.com/emojis/1184560248430805032.webp"
            );
            MachineInformations.WithImageUrl("https://media.discordapp.net/attachments/1111358828282388532/1172043117294264350/IMG_20231109_020343.png");
            MachineInformations.WithThumbnail(ArchE8.RezetRazor.CurrentUser.AvatarUrl);
            MachineInformations.AddField(
                "<:rezet_settings1:1147163366561955932> Developemt:",
                "> **My version**: `Arch 1.0`" +
                "\n> **Language**: `C# 12`" +
                "\n> **Library**: `DSharpPlus`" +
                $"\n> **Framework**: `.NET {Environment.Version}`"
            );
            var t = proc.PrivateMemorySize64 / 1024 / 1024;
            var ss = ArchE8.HerrscherRazor?._database?.GetCollection<BsonDocument>("Guilds");
            var stats = ss.Database.RunCommand<BsonDocument>(new BsonDocument { { "dbStats", 1 } });
            var st = Convert.ToDouble(stats["dataSize"]) / (1024 * 1024);
            var pingEmoji = "<:rezet_1_goodping:1147907217593479179>";
            if (ctx.Client.Ping > 40) { pingEmoji = "<:rezet_1_idelping:1147907282844274879>"; }
            else if (ctx.Client.Ping > 60) { pingEmoji = "<:rezet_1_badping:1147907161507246254>"; }
            MachineInformations.AddField(
                "<:rezet_settings1:1147163366561955932> Machine:",
                $"> {pingEmoji} **Ping**: `{ctx.Client.Ping}ms`" +
                $"\n> <:memory:1184559679406354432> **RAM**: `{t}MB / 2024MB`" +
                $"\n> <:ssd:1184559769697136730> **SSD**: `{fileSize:F2}MB`" +
                $"\n> <:database:1184560409005522965> **DB**: `{st:F2}MB / 512MB`"
            );



            
            int TotalUsers = 0;
            int TotalShards = 0;
            int TotalGuilds = 0;
            foreach (var v in ArchE8.RezetRazor.ShardClients.Values) {
                TotalShards++;
                TotalGuilds += v.Guilds.Count;
                foreach (var yy in v.Guilds.Values) {
                    TotalUsers += yy.MemberCount;
                }
            }
            var ShardClientInformations = new DiscordEmbedBuilder() {
                Description = $"> **Total shards**: `{TotalShards}`\n" +
                $"> **Total users**: `{TotalUsers}`\n> **Total servers**: `{TotalGuilds}`",
                Color = new DiscordColor("#2a2d30")
            };
            ShardClientInformations.WithAuthor(
                name: "Sharded Client",
                iconUrl: "https://cdn.discordapp.com/emojis/1147907330378309652.webp"
            );
            ShardClientInformations.WithImageUrl(
                "https://media.discordapp.net/attachments/1344162058996027453/1344169220526571520/IMG_20250226_014822.png"
            );
            var pingEmoji1 = "<:rezet_1_goodping:1147907217593479179>";
            foreach (var shard in ArchE8.RezetRazor.ShardClients.Values) {
                if (shard.Ping > 40) { pingEmoji1 = "<:rezet_1_idelping:1147907282844274879>"; }
                else if (shard.Ping > 60) { pingEmoji1 = "<:rezet_1_badping:1147907161507246254>"; }

                int ShardUsers = 0;
                int ShardChannels = 0;
                foreach (var s in shard.Guilds.Values) {
                    ShardUsers += s.MemberCount;
                    ShardChannels += s.Channels.Count;
                }

                ShardClientInformations.AddField(
                    $"<:rezet_plant:1308125160577962004> Shard {shard.ShardId}",
                    $"> <:rezet_box:1147164112091086920> **Servers**: `{shard.Guilds.Count}`" +
                    $"\n> <:rezet_Bugs:1148010355147153489> **Users**: `{ShardUsers}`" +
                    $"\n> <:rezet_channels:1308125117875752961> **Channels**: `{ShardChannels}`" + 
                    $"\n> {pingEmoji1} **Ping**: `{shard.Ping}ms`",
                    true
                );
            }




            await ctx.RespondAsync(
                builder: new DiscordMessageBuilder()
                    .WithContent("Bip bup bip!")
                    .AddEmbed(MachineInformations)
                    .AddEmbed(ShardClientInformations)
            );
        }
    }
}