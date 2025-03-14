using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Microsoft.VisualBasic;
using Rezet.Logging;
using Rezet.SlashCommands.CommunityCommands;
using Rezet.SlashCommands.SystemCommands;
using Rezet.Verify;



[SlashCommandGroup("community", "Community's commands.")]
public class CommunityCommands : ApplicationCommandModule {
    [SlashCommand("informations", "📘 | Sobre a comunidade.")]
    private static async Task Informations(InteractionContext ctx) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await GuildInfo.Command(ctx);


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
    private static async Task Description(InteractionContext ctx,
        [Option("description", "Nova descrição!")] string description
    ) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await GuildDescription.Command(ctx, description);


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


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            await GuildStats.Command(ctx);


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