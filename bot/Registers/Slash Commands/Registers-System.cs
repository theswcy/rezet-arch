using DSharpPlus.SlashCommands;
using Rezet.Logging;
using Rezet.SlashCommands.SystemCommands;
using Rezet.Verify;



// ========== COMMANDS LIST:
//      - /my system: OKAY.

// ========== NOTE:
// Nothing to do.



[SlashCommandGroup("my", "My system.")]
public class RezetSystems : ApplicationCommandModule {
    [SlashCommand("system", "✨ | Rezet Systems.")]
    public async Task MySystems(InteractionContext ctx) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await Sys.Informations(ctx);
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "/system",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
        }
    }
}