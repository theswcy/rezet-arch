using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Images;




namespace Rezet.SlashCommands.CommunityCommands {
    public class GuildStats {
        public static async Task Command(InteractionContext ctx) {
            var Members = await ctx.Guild.GetAllMembersAsync();
            double onlineMembers = Members.Count(m => m.Presence != null && 
            (m.Presence.Status == UserStatus.Online || 
             m.Presence.Status == UserStatus.Idle || 
             m.Presence.Status == UserStatus.DoNotDisturb));

            var embed = new DiscordEmbedBuilder()
            {
                Description = "## <:rezet_plant:1308125160577962004> Guild Stats!",
                Color = new DiscordColor("#7e67ff")
            };
            embed.WithImageUrl(RezetImages.ArchDivinder());
            int OnMe = (int)Math.Round(onlineMembers / Members.Count * 100); 
            int OfMe = (int)Math.Round((Members.Count - onlineMembers) / Members.Count  * 100);
            embed.AddField(
                "<:rezet_settings1:1147163366561955932> Porcentagem:",
                $"> <:rezet_globo:1147178426927681646> **Total**: `{Members.Count}`" +
                $"\n> <:rezet_dgreen:1147164307889586238> **Online**: `{onlineMembers}` ╺╸ **{OnMe}%**" +
                $"\n> <:rezet_dred:1147164215837208686> **Offline**: `{Members.Count - onlineMembers}` ╺╸ **{OfMe}%**"
            );
            double per = onlineMembers / Members.Count * 100;
            int GraphCount = (int)Math.Round(per / 10);
            string ONM = "<:rezet_dgreen:1147164307889586238>";
            string OFM = "<:rezet_dred:1147164215837208686>";
            string Graph = "";
            for (int i = 0; i < 10; i++) {
                if (i < GraphCount) {Graph += ONM; }
                else { Graph += OFM; }
            }
            embed.AddField(
                "<:rezet_channels:1308125117875752961> Gráfico:",
                $"\n> {Graph}"
            );



            await ctx.EditResponseAsync(
                new DiscordWebhookBuilder()
                    .WithContent("Bip bup bip")
                    .AddEmbed(embed)
            );
        }
    }
}