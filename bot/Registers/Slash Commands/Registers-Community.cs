using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;



[SlashCommandGroup("community", "Community's commands.")]
public class CommunityCommands : ApplicationCommandModule {
    [SlashCommand("informations", "📘 | Sobre a comunidade.")]
    private static async Task Informations(InteractionContext ctx) {
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
    [SlashCommand("description", "📘 | Alterar descrição da comunidade!")]
    private static async Task Description(InteractionContext ctx) {
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
    [SlashCommand("stats", "📘 | Visualizar statísticas da comunidade!")]
    private static async Task Stats(InteractionContext ctx) {
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