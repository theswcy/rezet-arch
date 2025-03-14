using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;
using Rezet.SlashCommands.SystemCommands;
using Rezet.Verify;



[SlashCommandGroup("my", "My system.")]
public class RezetSystems : ApplicationCommandModule {
    [SlashCommand("system", "✨ | Rezet Systems.")]
    private static async Task MySystems(InteractionContext ctx) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await Sys.Informations(ctx);


            await Task.CompletedTask;
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "/partnership open dashboard",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
            await Task.CompletedTask;
        }
    }
}