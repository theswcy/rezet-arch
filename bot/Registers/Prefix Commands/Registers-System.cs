using DSharpPlus.CommandsNext;
using Rezet.Logging;
using DSharpPlus.CommandsNext.Attributes;
using Rezet.PrefixCommands.SystemCommands;



public class PrefixSystemCommands : BaseCommandModule {
    [Command("system")]
    public async Task System(CommandContext ctx) {
        try {
            await ctx.Channel.TriggerTypingAsync();


            await PrefixSys.Informations(ctx);
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "system",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
        }
    }
}