using DSharpPlus;
using DSharpPlus.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Rezet.Logging;
using Rezet.LuminyCache;



#pragma warning disable CS8602
#pragma warning disable CS8603
namespace Rezet.HerrscherSearch {
    public class HerrscherServices {
        public readonly IMongoDatabase? _database;
        public static readonly int HerrschersCount = 2;
        public HerrscherServices(string ConnectionString, string HerrscherExtension) {
            try {
                var client = new MongoClient(ConnectionString);
                _database = client.GetDatabase(HerrscherExtension);
                RezetLogs.HerrscherConnect();
            } catch (Exception ex) {
                RezetLogs.HerrscherError(ex.Message);
            }
        }





        // ========== RETURN GUILD STRUCTURE:
        public BsonDocument GetGuildStructure(DiscordClient client, DiscordGuild Guild) {
            try {
                if (GuildCache.GetGuild(client, $"{Guild.Id}") != null) {
                    BsonDocument? GuildStructure = GuildCache.GetGuild(client, $"{Guild.Id}");
                    return GuildStructure;
                } else {
                    for (int HerrscherNumber = 0; HerrscherNumber <= HerrschersCount; HerrscherNumber++) {
                        var HerrscherExtension = _database.GetCollection<BsonDocument>("HerrscherGuilds");
                        var HerrscherFilter = Builders<BsonDocument>.Filter.Eq("_id", $"shard_{HerrscherNumber}");
                        var SelectedHerrscher = HerrscherExtension.Find(HerrscherFilter).FirstOrDefault();


                        if (SelectedHerrscher != null && SelectedHerrscher.Contains($"{Guild.Id}")) {
                            GuildCache.SaveGuild(client, $"{Guild.Id}", SelectedHerrscher[$"{Guild.Id}"].AsBsonDocument);
                            return SelectedHerrscher[$"{Guild.Id}"].AsBsonDocument;
                        } else {
                            RezetLogs.HerrscherGetDocument(HerrscherNumber, Guild.Name, $"{Guild.Id}");
                        }
                    }
                    return null;
                }
            } catch (Exception ex) {
                RezetLogs.HerrscherSelectError(ex.Message);
                return null;
            }
        }





        // ========== RETURN HERRSCHER STRUCTURE:
        public BsonDocument? GetHerrscherStructure(DiscordGuild Guild) {
            try {
                for (int HerrscherNumber = 0; HerrscherNumber <= HerrschersCount; HerrscherNumber++) {
                    var HerrscherExtension = _database.GetCollection<BsonDocument>("HerrscherGuilds");
                    var HerrscherFilter = Builders<BsonDocument>.Filter.Eq("_id", $"shard_{HerrscherNumber}");
                    var SelectedHerrscher = HerrscherExtension.Find(HerrscherFilter).FirstOrDefault();


                    if (SelectedHerrscher != null && SelectedHerrscher.Contains($"{Guild.Id}")) {
                        return SelectedHerrscher;
                    } else {
                        RezetLogs.HerrscherGetDocument(HerrscherNumber, Guild.Name, $"{Guild.Id}");
                    }
                }
                return null;
            } catch (Exception ex) {
                RezetLogs.HerrscherSelectError(ex.Message);
                return null;
            }
        }
    }
}