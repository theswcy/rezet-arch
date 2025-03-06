using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;



[SlashCommandGroup("partnership", "Partnerhip's commands.")]
public class PartnershipCommands : ApplicationCommandModule {
    [SlashCommandGroup("open", "Open the dashboard.")]
    private class Open : ApplicationCommandModule {
        [SlashCommand("dashboard", "🎋 | Dashboard de parcerias!")]
        private static async Task Dashboard(InteractionContext ctx) {
            try {
                await ctx.DeferAsync();


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
        [SlashCommand("setup", "🎋 | Configurar função de parcerias.")]
        public static async Task Activate(InteractionContext ctx,
            [Option("channel", "Canal de parcerias.")] DiscordChannel channel,
            [Option("ping", "Ping de notificação de novas parcerias.")] DiscordRole ping,
            [Option("role", "Cargo que será dado aos novos parceiros.")] DiscordRole role,
            [Option("logs", "Canal de logs de parcerias (recomendado configurar).")] DiscordChannel? logs = null
        ) {
            try {
                await ctx.DeferAsync();


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
    [SlashCommandGroup("ranking", "The partnership's ranking.")]
    private class Ranking : ApplicationCommandModule {
        [SlashCommand("local", "🎋 | Leaderboard local de parcerias!")]
        private static async Task Local(InteractionContext ctx) {
            try {
                await ctx.DeferAsync();


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
        [SlashCommand("global", "🎋 | Leaderboard global de parcerias")]
        private static async Task Global(InteractionContext ctx) {
            try {
                await ctx.DeferAsync();

                
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
}