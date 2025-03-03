using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.CommandsNext;



#pragma warning disable CS8602
namespace Rezet.Verify {
    public class IsOnGuild {
        public static async Task<bool> VerifySlash(InteractionContext ctx, DiscordUser user) {
            if (await ctx.Guild.GetMemberAsync(user.Id) == null) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Hey, o usuário `{user.Username}` não está presente no servidor!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> VerifyPrefix(CommandContext ctx, DiscordUser user) {
            if (await ctx.Guild.GetMemberAsync(user.Id) == null) {
                await ctx.RespondAsync($"Hey, o usuário `{user.Username}` não está presente no servidor!");
                return false;
            } else {
                return true;
            }
        }
    }





    public class VerifyRoleType {
        public static async Task<bool> RoleTypeSlash(InteractionContext ctx, DiscordRole role) {
            if (role.Id == ctx.Guild.EveryoneRole.Id) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent("Ops, cargo **everyone** não pode ser gerenciado!")
                );
                return false;
            } else if (role.IsManaged) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Ops, cargo **{role.Name}** não pode ser gerenciado!")
                );
                return false;
            } else if (ctx.Guild.Roles.Values.FirstOrDefault(r => r.Tags.IsPremiumSubscriber) != null) {
                if (role.Id == ctx.Guild.Roles.Values.FirstOrDefault(r => r.Tags.IsPremiumSubscriber).Id) {
                    await ctx.EditResponseAsync(
                        new DiscordWebhookBuilder()
                            .WithContent($"Ops, cargo **{role.Name}** não pode ser gerenciado!")
                    );
                return false;
                } else {
                    return true;
                }
            }
            return true;
        }
        public static async Task<bool> RoleTypePrefix(CommandContext ctx, DiscordRole role) {
            if (role.Id == ctx.Guild.EveryoneRole.Id) {
                await ctx.RespondAsync("Ops, cargo **everyone** não pode ser gerenciado!");
                return false;
            } else if (role.IsManaged) {
                await ctx.RespondAsync($"Ops, cargo **{role.Name}** não pode ser gerenciado!");
                return false;
            } else if (ctx.Guild.Roles.Values.FirstOrDefault(r => r.Tags.IsPremiumSubscriber) != null) {
                if (role.Id == ctx.Guild.Roles.Values.FirstOrDefault(r => r.Tags.IsPremiumSubscriber).Id) {
                    await ctx.RespondAsync($"Ops, cargo **{role.Name}** não pode ser gerenciado!");
                    return false;
                } else {
                    return true;
                }
            }
            return true;
        }
    }




    
    public class VerifyRolePosition {
        public static async Task<bool> UserPositionSlash(InteractionContext ctx, DiscordRole role) {
            var HighestMemberRole = ctx.Member.Roles.OrderByDescending(r => r.Position).FirstOrDefault();


            if (role.Position >= HighestMemberRole.Position) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Você não gerenciar um cargo maior que o seu maior cargo atual!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> UserPositionPrefix(CommandContext ctx, DiscordRole role) {
            var HighestMemberRole = ctx.Member.Roles.OrderByDescending(r => r.Position).FirstOrDefault();


            if (role.Position >= HighestMemberRole.Position) {
                await ctx.RespondAsync($"Você não gerenciar um cargo maior que o seu maior cargo atual!");
                return false;
            } else {
                return true;
            }
        }




        public static async Task<bool> RezetPositionSlash(InteractionContext ctx, DiscordRole role) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            var HighestMemberRole = m.Roles.OrderByDescending(r => r.Position).FirstOrDefault();


            if (role.Position >= HighestMemberRole.Position) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Eu não posso gerenciar um cargo maior que o meu maior cargo atual!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> RezetPositionPrefix(CommandContext ctx, DiscordRole role) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            var HighestMemberRole = m.Roles.OrderByDescending(r => r.Position).FirstOrDefault();


            if (role.Position >= HighestMemberRole.Position) {
                await ctx.RespondAsync($"Eu não posso gerenciar um cargo maior que o meu maior cargo atual!");
                return false;
            } else {
                return true;
            }
        }




        public static async Task<bool> EnemyUserPositionSlash(InteractionContext ctx, DiscordMember member) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            var HighestMemberRole = m.Roles.OrderByDescending(r => r.Position).FirstOrDefault();
            var EnemyHighestMemberRole = member.Roles.OrderByDescending(r => r.Position).FirstOrDefault();


            if (EnemyHighestMemberRole.Position >= HighestMemberRole.Position) {
                await ctx.EditResponseAsync(
                    new DiscordWebhookBuilder()
                        .WithContent($"Você não gerenciar um membro com o cargo maior que o seu maior cargo atual!")
                );
                return false;
            } else {
                return true;
            }
        }
        public static async Task<bool> EnemyUserPositionPrefix(CommandContext ctx, DiscordMember member) {
            var m = await ctx.Guild.GetMemberAsync(ctx.Client.CurrentUser.Id);
            var HighestMemberRole = m.Roles.OrderByDescending(r => r.Position).FirstOrDefault();
            var EnemyHighestMemberRole = member.Roles.OrderByDescending(r => r.Position).FirstOrDefault();


            if (EnemyHighestMemberRole.Position >= HighestMemberRole.Position) {
                await ctx.RespondAsync($"Eu não posso gerenciar um membro com o cargo maior que o meu maior cargo atual!");
                return false;
            } else {
                return true;
            }
        }
    }
}