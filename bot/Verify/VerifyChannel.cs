using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.CommandsNext;



#pragma warning disable CS8602
namespace Rezet.Verify {
    public class VerifyChannelType {
        public static async Task<bool> VerifyPrivateSlash(InteractionContext ctx, DiscordChannel channel) {
            if (channel.Type == ChannelType.Private) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent("Hey, eu não executo comandos no privado!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> VerifyPrivatePrefix(CommandContext ctx, DiscordChannel channel) {
            if (channel.Type == ChannelType.Private) {
                await ctx.RespondAsync("Hey, eu não executo comandos no privado!");
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> TypeSlash(InteractionContext ctx, DiscordChannel channel, ChannelType type) {
            if (channel.Type != type) {
                if (channel.Type == ChannelType.News) {
                    return true;
                } else if (channel.Type == ChannelType.PublicThread) {
                    return true;
                } else if (channel.Type == ChannelType.PrivateThread) {
                    return true;
                } else {
                    await ctx.EditResponseAsync(
                        new DiscordWebhookBuilder()
                            .WithContent($"Ops, o canal selecionado não é um canal do tipo **{type}**!")
                    );
                    return false;
                }
            } else {
                return true;
            }
        }
        public static async Task<bool> TypePrefix(CommandContext ctx, DiscordChannel channel, ChannelType type) {
            if (channel.Type != type) {
                if (channel.Type == ChannelType.News) {
                    return true;
                } else if (channel.Type == ChannelType.PublicThread) {
                    return true;
                } else if (channel.Type == ChannelType.PrivateThread) {
                    return true;
                } else {
                    await ctx.RespondAsync($"Ops, o canal selecionado não é um canal do tipo **{type}**!");
                    return false;
                }
            } else {
                return true;
            }
        }
    }





    public class VerifyChannelPermissions {
        public static async Task<bool> VerifyUserSlash(InteractionContext ctx, DiscordChannel channel) {
            var p = channel.PermissionsFor(ctx.Member);

            
            if (ctx.Member.IsOwner || ctx.Member.Permissions.HasPermission(Permissions.Administrator)) {
                return true;
            } else if (!p.HasPermission(Permissions.AccessChannels)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, você não tem permissão para **acessar** o canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else if (!p.HasPermission(Permissions.ManageChannels)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, você não tem permissão para **gerenciar** o canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else if (!p.HasPermission(Permissions.SendMessages)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, você não tem permissão para **enviar mensagens** no canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> VerifyUserPrefix(CommandContext ctx, DiscordChannel channel) {
            var p = channel.PermissionsFor(ctx.Member);


            if (ctx.Member.IsOwner || ctx.Member.Permissions.HasPermission(Permissions.Administrator)) {
                return true;
            } else if (!p.HasPermission(Permissions.AccessChannels)) {
                await ctx.RespondAsync($"Ops, você não tem permissão para **acessar** o canal {channel.Mention} [ `{channel.Id}` ]!");
                return false;
            } else if (!p.HasPermission(Permissions.ManageChannels)) {
                await ctx.RespondAsync($"Ops, você não tem permissão para **gerenciar** o canal {channel.Mention} [ `{channel.Id}` ]!");
                return false;
            } else if (!p.HasPermission(Permissions.SendMessages)) {
                await ctx.RespondAsync($"Ops, você não tem permissão para **enviar mensagens** no canal {channel.Mention} [ `{channel.Id}` ]!");
                return false;
            } else {
                return true;
            }
        }





        public static async Task<bool> VerifyRezetSlash(InteractionContext ctx, DiscordChannel channel) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            var p = channel.PermissionsFor(m);


            if (m.IsOwner || m.Permissions.HasPermission(Permissions.Administrator)) {
                return true;
            } else if (!p.HasPermission(Permissions.AccessChannels)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, eu não tenho permissão para **acessar** o canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else if (!p.HasPermission(Permissions.ManageChannels)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, eu não tenho permissão para **gerenciar** o canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else if (!p.HasPermission(Permissions.ManageMessages)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, eu não tenho permissão para **gerenciar as mensagens** no canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else if (!p.HasPermission(Permissions.SendMessages)) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, eu não tenho permissão para **enviar mensagens** no canal {channel.Mention} [ `{channel.Id}` ]!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> VerifyRezetPrefix(CommandContext ctx, DiscordChannel channel) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            var p = channel.PermissionsFor(m);

            
            if (m.IsOwner || m.Permissions.HasPermission(Permissions.Administrator)) {
                return true;
            } else if (!p.HasPermission(Permissions.AccessChannels)) {
                await ctx.RespondAsync($"Ops, você não tem permissão para **acessar** o canal {channel.Mention} [ `{channel.Id}` ]!");
                return false;
            } else if (!p.HasPermission(Permissions.ManageChannels)) {
                await ctx.RespondAsync($"Ops, você não tem permissão para **gerenciar** o canal {channel.Mention} [ `{channel.Id}` ]!");
                return false;
            } else if (!p.HasPermission(Permissions.SendMessages)) {
                await ctx.RespondAsync($"Ops, você não tem permissão para **enviar mensagens** no canal {channel.Mention} [ `{channel.Id}` ]!");
                return false;
            } else {
                return true;
            }
        }
    }
}