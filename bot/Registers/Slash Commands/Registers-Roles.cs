using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;



[SlashCommandGroup("role", "Role Settings")]
public class RolesCommands : ApplicationCommandModule {
    [SlashCommand("add", "📗 | Adicionar um cargo a um usuário.")]
    public static async Task Add(InteractionContext ctx,
        [Option("role", "Selecione o cargo que será adicionado.")] DiscordRole role,
        [Option("member", "Selecione o membro que receberá o cargo")] DiscordUser member,
        [Option("reason", "Motivo do membro ter recebido o cargo.")] string? Reason = null
    ) {
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
    [SlashCommand("remove", "📗 | Remover um cargo de um usuário.")]
    public static async Task Remove(InteractionContext ctx,
        [Option("role", "Selecione o cargo que será removido.")] DiscordRole role,
        [Option("member", "Selecione o membro que perderá o cargo.")] DiscordUser member,
        [Option("reason", "Motivo do membro ter perdido o cargo.")] string? Reason = null
    ) {
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
    [SlashCommand("info", "📗 | Mostrar as informações de um cargo!")]
    public static async Task Info(InteractionContext ctx,
        [Option("role", "Selecione o cargo.")] DiscordRole role
    ) {
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
    [SlashCommand("create", "📗 | Criar um cargo!")]
    public static async Task Create(InteractionContext ctx,
        [Option("name", "Nome do cargo.")] string name,
        [Option("member", "Adicionar o cargo a um membro.")] DiscordUser? user = null,
        [Option("color", "Cor do cargo. [ ex: #FF0000 ]")] string? colorhex = null,
        [Option("perms", "Adicionar permissões ao cargo.")]
            [Choice("basics", 1)]
            [Choice("moderation", 2)]
            [Choice("manager", 3)]
            long perms = 0,
        [Option("time", "Deletar depois de um tempo.")]
            [Choice("1 minute", 1)]
            [Choice("5 minutes", 5)]
            [Choice("10 minutes", 10)]
            [Choice("30 minutes", 30)]
            [Choice("1 hour", 100)]
            [Choice("2 hours", 200)]
            [Choice("6 hours", 600)]
            [Choice("12 hours", 1200)]
            [Choice("1 day", 2400)]
            [Choice("2 days", 4800)]
            long? time = 0
    ) {
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