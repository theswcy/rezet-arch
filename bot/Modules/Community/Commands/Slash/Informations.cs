using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;




#pragma warning disable CS8602
namespace Rezet.SlashCommands.CommunityCommands {
    public class GuildInfo {
        public static async Task Command(InteractionContext ctx) {
            var Guild = await ctx.Client.GetGuildAsync(ctx.Guild.Id);
            await Guild.RequestMembersAsync();
            var Members = await Guild.GetAllMembersAsync();
            var Channels = await Guild.GetChannelsAsync();
            var Roles = Guild.Roles;



            int bl = 0;
            var bc = Guild.PremiumSubscriptionCount;
            string BoostBadge = "<:rezet_globo:1147178426927681646>";
            if (bc == 1) { BoostBadge = "<:rezet_sb_0:1171817483779457186>"; }
            else if (bc >= 2 && bc < 7) { BoostBadge = "<:rezet_sb_1:1171817556319936583>"; bl = 1; }
            else if (bc >= 7 && bc < 14) { BoostBadge = "<:rezet_sb_2:1171817619762991204>"; bl = 2; }
            else if (bc >= 14) { BoostBadge = "<:rezet_sb_3:1171817673852715008>"; bl = 3; }
            

            
            var embed = new DiscordEmbedBuilder {
                Description = 
                    $"## {BoostBadge} {Guild.Name}\n" +
                    $"- {Guild.Description ?? "<:rezet_dred:1147164215837208686> Essa comunidade não possui descrição."}\n⠀",
                Color = new DiscordColor("#7e67ff")
            };
            if (Guild.IconUrl != null) { embed.WithThumbnail(Guild.IconUrl); }
            if (Guild.SplashUrl != null) { embed.WithImageUrl(Guild.SplashUrl); }
            else if (Guild.BannerUrl != null) { embed.WithImageUrl(Guild.BannerUrl); }
            embed.AddField(
                "<:rezet_creditcard:1147341888538542132> Basics",
                $"> **Owner**: {Guild.Owner.DisplayName} | `{Guild.OwnerId}`" +
                $"\n> **Type**: `Community`"
            );
            embed.AddField(
                "<:rezet_colornitrod:1164416963121008701> Boost",
                $"> **Boost role**: {(Guild.Roles.Values.FirstOrDefault(r => r.Tags.IsPremiumSubscriber) != null ? Guild.Roles.Values.FirstOrDefault(r => r.Tags.IsPremiumSubscriber).Mention : "**Uncativated**.")}" +
                $"\n> **Boosts**: `{Guild.PremiumSubscriptionCount}`" +
                $"\n> **Level**: `{bl}`"
            );



            int onlineMembers = Members.Count(m => m.Presence != null && 
                (m.Presence.Status == UserStatus.Online || 
                 m.Presence.Status == UserStatus.Idle || 
                 m.Presence.Status == UserStatus.DoNotDisturb));
            embed.AddField(
                "<:rezet_globo:1147178426927681646> Members",
                $"> <:rezet_dgreen:1147164307889586238> `{onlineMembers}` **Online**." +
                $"\n> <:rezet_dred:1147164215837208686> `{Members.Count - onlineMembers}` **Offline**." +
                $"\n> <:rezet_shine:1147373071737573446> `{Members.Count(m => m.IsBot)}` **Bots**." +
                $"\n> <:rezet_globo:1147178426927681646> `{Members.Count}` **Total**."
            );


            
            embed.AddField(
                "<:rezet_connect:1147907330378309652> Channels",
                $"> `{Channels.Count(c => c.Type == ChannelType.Text)}` **Text**." + 
                $"\n> `{Channels.Count(c => c.Type == ChannelType.Voice)}` **Voice**." +
                $"\n> `{Channels.Count(c => c.Type == ChannelType.GuildForum)}` **Forum**." +
                $"\n> `{Channels.Count(c => c.Type == ChannelType.Stage)}` **Stage**." +
                $"\n> `{Channels.Count(c => c.Type == ChannelType.Category)}` **Category**." +
                $"\n> `{Channels.Count(c => c.Type == ChannelType.PublicThread)}` **Public Threads**." +
                $"\n> `{Channels.Count(c => c.Type == ChannelType.PrivateThread)}` **Private Threads**." +
                $"\n> `{Channels.Count(c => c.Type == ChannelType.News)}` **Announcement**." 
            );


            int z = 0;
            foreach (var entry in Roles) { if (entry.Value.IsManaged) {z++;} }
            embed.AddField(
                "<:rezet_share:1147165266887856209> Roles",
                $"> `{Roles.Count}` **Roles**." +
                $"\n> `{z}` **Managed**."
            );



            await ctx.EditResponseAsync(
                new DiscordWebhookBuilder()
                    .WithContent("Bip bup bip!")
                    .AddEmbed(embed)
                );
        }
    }
}