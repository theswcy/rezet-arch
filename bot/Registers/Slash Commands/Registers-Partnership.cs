using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;
using Rezet.Verify;



// ========== COMMANDS LIST:
//      - /partnership open dashboard: to create.
//      - /partnership open setup: to create.
//      - /partnership ranking local: to create.
//      - /partnership ranking global: to create.
//      - /partnership ranking points: to create.

// ========== NOTE:
// Create commands function and update options.



[SlashCommandGroup("partnership", "Partnerhip's commands.")]
public class PartnershipCommands : ApplicationCommandModule {
    [SlashCommandGroup("open", "Open the dashboard.")]
    private class Open : ApplicationCommandModule {
        [SlashCommand("dashboard", "🎋 | Dashboard de parcerias!")]
        private static async Task Dashboard(InteractionContext ctx) {
            try {
                await ctx.DeferAsync();


                if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            } catch (Exception ex) {
                RezetLogs.SlashCommandError(
                    "/partnership open dashboard",
                    $"{ctx.User.Username}", $"{ctx.User.Id}",
                    $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                    $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                    $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                );
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


                if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            } catch (Exception ex) {
                RezetLogs.SlashCommandError(
                    "/partnership open setup",
                    $"{ctx.User.Username}", $"{ctx.User.Id}",
                    $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                    $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                    $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                );
            }
        }
    }
    [SlashCommandGroup("ranking", "The partnership's ranking.")]
    private class Ranking : ApplicationCommandModule {
        [SlashCommand("local", "🎋 | Leaderboard local de parcerias!")]
        private static async Task Local(InteractionContext ctx) {
            try {
                await ctx.DeferAsync();


                if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            } catch (Exception ex) {
                RezetLogs.SlashCommandError(
                    "/partnership ranking local",
                    $"{ctx.User.Username}", $"{ctx.User.Id}",
                    $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                    $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                    $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                );
            }
        }
        [SlashCommand("global", "🎋 | Leaderboard global de parcerias!")]
        private static async Task Global(InteractionContext ctx) {
            try {
                await ctx.DeferAsync();


                if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            } catch (Exception ex) {
                RezetLogs.SlashCommandError(
                    "/partnership ranking global",
                    $"{ctx.User.Username}", $"{ctx.User.Id}",
                    $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                    $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                    $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                );
            }
        }
        [SlashCommand("points", "🎋 | Modificar os pontos de parceria de algum usuário!")]
        private static async Task Points(InteractionContext ctx,
            [Option("action", "Selecione a ação.")]
                [Choice("add", "Adicionar pontos.")]
                [Choice("remove", "Remover pontos.")] string Action,
            [Option("amount", "Quantidade de pontos que serão adicionados ou removidos.")] long Amount,
            [Option("user", "Usuário que terá os pontos modificados.")] DiscordMember User
        ) {
            try {
                await ctx.DeferAsync();


                if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
            } catch (Exception ex) {
                RezetLogs.SlashCommandError(
                    "/partnership ranking global",
                    $"{ctx.User.Username}", $"{ctx.User.Id}",
                    $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                    $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                    $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                );
            }
        }
    }
}