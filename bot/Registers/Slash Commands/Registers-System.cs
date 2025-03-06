using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;



[SlashCommandGroup("my", "My system.")]
public class RezetSystems : ApplicationCommandModule {
    [SlashCommand("system", "✨ | Rezet Systems.")]
    public static async Task MySystems(InteractionContext ctx) {
        try {
            await ctx.DeferAsync();
            await ctx.Channel.TriggerTypingAsync();


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