using DSharpPlus;
using MongoDB.Driver;
using MongoDB.Bson;
using Rezet.HerrscherSearch;
using DSharpPlus.EventArgs;
using Rezet.Logging;



#pragma warning disable CS8602
namespace Rezet.Events.SystemEvents {
    public class AddGuildOnHerrscher {
        public static async Task Update(DiscordClient Client, GuildCreateEventArgs e) {
            try {
                var NewGuildDatabase = new BsonDocument {
                    // ========== GENERAL COMMUNITY CONFIGS.
                    { "GuildName", e.Guild.Name },
                    { "GuildType", "Community" }, // <- Community, Alliance, Support, Roleplay Game.
                    { "GuildLang", "pt-br" }, // <- en-us, ru-ru.
                    // ========== BADGES.
                    { "GuildBadges", new BsonDocument {
                        { "partner", false },
                        { "debug", false },
                        { "donate", false },
                    } },
                    // ========== MODERATORS CONFIGS.
                    { "GuildModers", new BsonDocument {
                    //  { "user_id", new BsonDocument {
                    //      { "bans", 0 },
                    //      { "kicks", 0 },
                    //      { "warns", 0 },
                    //      { "mutes", 0 },
                    //      { "added", "" }, <- Moderator add date.
                    //      { "reputation", 0 },
                    //      { "hours_works", "" } <- PM, AM or full-time.
                    //      { "last_actions", new BsonDocument {
                    //          { "case_name", new BsonDocument {
                    //              { "type", "" }, <- Ban, kick, mute or warn.
                    //              { "description", "" },
                    //              { "date", "" }
                    //          } }
                    //      } }
                    //  } }
                       } },
                    // ========== MODERATION CONFIGS.
                    { "moderation", new BsonDocument {
                        { "key_pass", "" }, // <- Security PassKey.
                        // ========== LOGGING CONFIGS WITH CHANNELS IDs | function = channel_id.
                        { "mod_logs", new BsonDocument {
                            { "messages", BsonNull.Value }, // <- Deleted or modified message.
                            { "moderation_actions", BsonNull.Value }, // <- Ban/Unban, Mute/Unmute, Warn/Unwarn/Warn modify, kick or prune.
                            { "manage_guild", BsonNull.Value }, // <- Name, description, icon, banner, splash, bot add/remove.
                            { "modified_roles", BsonNull.Value }, // <- Create, delete or modify.
                            { "modified_channels", BsonNull.Value }, // <- Create, delete or modify.
                            { "modified_users", BsonNull.Value } // <- Name change, role add or remove.
                        } },
                        // ========== SECURITY CONFIGS:
                        { "security", new BsonDocument {
                            { "sharp-mode", false }, // <- Incoming.
                            { "anti-invites", new BsonDocument {
                                { "activated", false },
                                { "except", BsonNull.Value } // <- Max 10 channels.
                            } },
                            { "anti-raid", new BsonDocument {
                                { "activated", false },
                                { "messages_amount", 5 },
                                { "messages_interval", 2 },
                                { "accumulated", new BsonDocument {
                                    { "strikes", 3 },
                                    { "interval", 10 },
                                    { "action", 2 } // <- 1 mute | 2 kick | 3 ban.
                                } }, 
                                { "except", BsonNull.Value } // <- Max 10 channels.
                            } },
                            { "blackout", new BsonDocument {
                                { "activated", false },
                                { "tier", 0 },
                                { "action", 1 } // <- 1 clear roles | 2 kick | 3 ban.
                            } }
                        } },
                        // ========== AUTOMATIC ACTIONS.
                        { "auto_actions", new BsonDocument {
                            { "autorole", BsonNull.Value }, // <- Max 10 roles.
                            { "autoping", new BsonDocument { // <- Max 10 channels.
                        //      { "text", "" },
                        //      { "ping", "" },
                        //      { "channel", 0 }
                            } }
                        } },
                        // ========== WARNS CONFIGS.
                        { "warns", new BsonDocument {
                            { "count", 0 },
                            { "cases", new BsonDocument { 
                        //      { "case_id", "" },
                        //      { "case_number", 0 },
                        //      { "author", 0 },
                        //      { "user", 0 },
                        //      { "reason", "" },
                        //      { "date", "" }
                            } }
                        } }
                    } },
                    // ========== SPECIAL FEATURES.
                    { "features", new BsonDocument {
                        { "welcome_message", new BsonDocument {
                            { "activated", false },
                            { "channel", BsonNull.Value },
                            { "embed", new BsonDocument {
                                { "title", "Bem vindo(a)!" },
                                { "description", "A comunidade @[guild.name] tem o prazer de receber você, @[user.mention]!" },
                                { "image", 0 }, // <- 0 null | 1 guild splash | 2 guild banner | 3 custom image.
                                { "thumbnail", 0 } // <- 0 null | 1 guild icon | 2 user icon | 3 custom image.
                            } }
                        } },
                        { "goodbye_message", new BsonDocument {
                            { "activated", false },
                            { "channel", BsonNull.Value },
                            { "embed", new BsonDocument {
                                { "title", "Noooo, ele(a) saiu do servidor!" },
                                { "description", "Infelizmente, @[user.mention] saiu da nossa comunidade..." },
                                { "image", 0 }, // <- 0 null | 1 guild splash | 2 guild banner | 3 custom image.
                                { "thumbnail", 0 } // <- 0 null | 1 guild icon | user icon | 3 custo image.
                            } }
                        } }
                    } },
                    // ========== PARTNERSHIP CONFIGS.
                    { "partnership", new BsonDocument {
                        { "count", 0 }, // <- Total partnerships count.
                        { "exp", 0 }, // <- Total experiences count.
                        { "points", 0 }, // <- Ranking points count.
                        { "channel_logs", BsonNull.Value },
                        { "anti-eh", 0 },
                        { "anti-qi", false },
                        { "invite", BsonNull.Value },
                        // ========== INSTANCE SETTINGS.
                        { "instances", new BsonDocument { // <- Max 5 instances.
                            { "primary", new BsonDocument {
                                { "activated", false },
                                { "count", 0 }, // <- Partnerships count in this instance.
                                { "exp", 0 }, // <- Experiences count in this instance.
                                { "role", BsonNull.Value }, // <- Partnership role.
                                { "ping", BsonNull.Value }, // <- Announcement ping.
                                { "message", "default" },
                                { "channels", new BsonDocument { // <- Max 5 channels.
                                //  { "channel_id", "channel_id" }
                                } },
                                // ========== INSTANCE LEADERBOARD
                                { "leaderboard", new BsonDocument {
                                //  { "user_id", 0 }
                                } }
                            } }
                        } },
                        // ========== GLOBAL EMBEDS.
                        { "embeds", new BsonDocument { // <- Max 10 embeds.
                            { "default", new BsonDocument {
                                { "content", "Nova parceria!" },
                                { "title", "Partnership!" },
                                { "description", "Uma nova parceria foi feita com a nossa comunidade **@[guild.name]**!" },
                                { "footer", "Managed by Rezet!" },
                                { "color", "#7e67ff" },
                                { "image", "https://media.discordapp.net/attachments/1111358828282388532/1172043117294264350/IMG_20231109_020343.png" },
                                { "thumb", 0 },
                                { "author", 0 }
                            } }
                        } },
                        // ========== GLOBAL METRICS.
                        { "metrics", new BsonDocument {
                            { "months", new BsonDocument {
                        //      { "month_name", 0 }
                            } }
                        //  { "month_name", new BsonDocument {
                        //      { "1", 0 }
                        //  } }
                        } },
                        // ========== GLOBAL LOCAL LEADERBOARD.
                        { "leaderboard", new BsonDocument {
                        //  { "user_id", 0 }
                        } }
                    } }
                };


                for (int HerrscherNumber = 0; HerrscherNumber <= HerrscherServices.HerrschersCount; HerrscherNumber++) {
                    var HerrscherExtension = ArchE8.HerrscherRazor?._database?.GetCollection<BsonDocument>("HerrscherGuilds");
                    var HerrscherFilter = Builders<BsonDocument>.Filter.Eq("_id", $"shard_{HerrscherNumber}");
                    var SelectedHerrscher = HerrscherExtension.Find(HerrscherFilter).FirstOrDefault();


                    if (SelectedHerrscher != null && !SelectedHerrscher.Contains($"{e.Guild.Id}")) {
                        if (SelectedHerrscher.ElementCount < 1000) {
                            var HerrscherUpdate = Builders<BsonDocument>.Update.Set($"{e.Guild.Id}", NewGuildDatabase);
                            await HerrscherExtension.UpdateOneAsync(HerrscherFilter, HerrscherUpdate);
                            break;
                        }
                    }
                }
                await Task.CompletedTask;
            } catch (Exception ex) {
                RezetLogs.HandlerError(
                    "GUILD CREATE EVENT",
                    $"- {ex.GetType()}\n- {ex.Message}\n{ex.StackTrace}"
                );
            }
        }
    }
}