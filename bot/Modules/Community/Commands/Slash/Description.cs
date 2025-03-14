using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Verify;
using Rezet.Images;




namespace Rezet.SlashCommands.CommunityCommands {
    public class GuildDescription {
        public static async Task Command(InteractionContext ctx, string description) {
            var Author = ctx.Member;


            if (await VerifyPermissions.VerifyUserSlash(ctx, Permissions.ManageGuild) is false) { return; }
            if (await VerifyPermissions.VerifyRezetSlash(ctx, Permissions.ManageGuild) is false) { return; }


            if (description.Length > 120) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent("Hey, a descrição da comunidade deve ter no máximo **120** caracteres!")
                );
                return;
            }


            var Embed = new DiscordEmbedBuilder() {
                Description = "Descrição alterada!",
                Color = new DiscordColor("#7e67ff")
            };
            if (ctx.Guild.Description.Length > 0) {
                Embed.AddField(
                    "Antes:",
                    $"{ctx.Guild.Description}"
                );
            } else {
                Embed.AddField(
                    "Antes:",
                    $"Nenhuma descrição."
                );
            }


            await ctx.Guild.ModifyAsync(p => p.Description = description);
            Embed.AddField(
                "Depois:",
                $"{description}"
            );
            Embed.WithImageUrl(RezetImages.ArchDivinder());


            await ctx.EditResponseAsync(
                new DiscordWebhookBuilder()
                    .WithContent("Bip bup bip!")
                    .AddEmbed(Embed)
            );
        }
    }
}