using DSharpPlus.SlashCommands;
using Rezet.Logging;
using Rezet.SlashCommands.CommunityCommands;
using Rezet.Verify;



// ========== COMMANDS LIST:
//      - /community informations: OK.
//      - /community description: OK.
//      - /community stats: OK.

// ========== NOTE:
// Nothing to do.



[SlashCommandGroup("community", "Community's commands.")]
public class CommunityCommands : ApplicationCommandModule {
    [SlashCommand("informations", "📘 | Sobre a comunidade.")]
    private static async Task Informations(InteractionContext ctx) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await GuildInfo.Command(ctx);
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "/community informations",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
        }
    }
    [SlashCommand("description", "📘 | Alterar descrição da comunidade!")]
    private static async Task Description(InteractionContext ctx,
        [Option("description", "Nova descrição!")] string description
    ) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await GuildDescription.Command(ctx, description);
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "/community description",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
        }
    }
    [SlashCommand("stats", "📘 | Visualizar statísticas da comunidade!")]
    private static async Task Stats(InteractionContext ctx) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await GuildStats.Command(ctx);
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "/community stats",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
        }
    }
}