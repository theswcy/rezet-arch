using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.CommandsNext;



namespace Rezet.Verify {
    public class VerifyPermissions {
        public static async Task<bool> VerifyUserSlash(InteractionContext ctx, Permissions permission) {
            var m = await ctx.Guild.GetMemberAsync(ctx.User.Id);
            

            if (!m.Permissions.HasPermission(permission) || !m.Permissions.HasPermission(Permissions.Administrator)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Hey, você não tem a permissão `{permission}` para usar o comando!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> VerifyUserPrefix(CommandContext ctx, Permissions permission) {
            var m = await ctx.Guild.GetMemberAsync(ctx.User.Id);


            if (!m.Permissions.HasPermission(permission) || !m.Permissions.HasPermission(Permissions.Administrator)) {
                await ctx.RespondAsync($"Hey, você não tem a permissão `{permission}` para usar o comando!");
                return false;
            } else {
                return true;
            }
        }





        public static async Task<bool> VerifyRezetSlash(InteractionContext ctx, Permissions permission) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            

            if (!m.Permissions.HasPermission(permission) || !m.Permissions.HasPermission(Permissions.Administrator)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Hey, eu não tenho a permissão `{permission}` para executar o comando!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> VerifyRezetPrefix(CommandContext ctx, Permissions permission) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);


            if (!m.Permissions.HasPermission(permission) || !m.Permissions.HasPermission(Permissions.Administrator)) {
                await ctx.RespondAsync($"Hey, eu não tenho a permissão `{permission}` para executar o comando!");
                return false;
            } else {
                return true;
            }
        }
    }
}