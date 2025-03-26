using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Rezet.Logging;
using Rezet.Verify;



// ========== COMMANDS LIST:
//      - /chat clear: to create.

// ========== NOTE:
// Create commands function.



[SlashCommandGroup("chat", "Chat settings.")]
public class ChatCommands : ApplicationCommandModule{
    [SlashCommand("clear", "💭 | Apagar mensagens!")]
    private static async Task Command(InteractionContext ctx,
        [Option("amount", "Quantidade de mensagens. [ max: 100 ]")] long amount,
        [Option("channel", "Deletar mensagens de um canal específico.")] DiscordChannel? channel = null,
        [Option("member", "Deletar mensagens de um membro específico..")] DiscordUser? member = null
    ) {
        try {
            await ctx.DeferAsync();


            if (await VerifyChannelType.VerifyPrivateSlash(ctx, ctx.Channel) is false) { return; }
        } catch (Exception ex) {
            RezetLogs.SlashCommandError(
                "/chat clear",
                $"{ctx.User.Username}", $"{ctx.User.Id}",
                $"{ctx.Guild.Name}", $"{ctx.Guild.Id}",
                $"{ctx.Channel.Name}", $"{ctx.Channel.Id}",
                $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
            );
        }
    }
}