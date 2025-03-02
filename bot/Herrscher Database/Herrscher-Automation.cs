using MongoDB.Driver;
using MongoDB.Bson;
using DSharpPlus.Entities;
using DSharpPlus;



#pragma warning disable CS8602
namespace Rezet.HerrscherAutomation {
    public class HerrscherAutomation {
        public static async Task UpdateAdd(DiscordClient client, DiscordGuild Guild, string map, dynamic content) {
            var Herrscher = ArchE8.HerrscherRazor.GetHerrscherStructure(Guild);
            var Collection = ArchE8.HerrscherRazor?._database?.GetCollection<BsonDocument>("guilds");
            var update = Builders<BsonDocument>.Update.Set($"{Guild.Id}.{map}", content);
            
            await Collection.UpdateOneAsync(Herrscher, update);
        }
        public static async Task UpdateRemove(DiscordClient client, DiscordGuild Guild, string map) {
            var Herrscher = ArchE8.HerrscherRazor.GetHerrscherStructure(Guild);
            var Collection = ArchE8.HerrscherRazor?._database?.GetCollection<BsonDocument>("guilds");
            var update = Builders<BsonDocument>.Update.Unset($"{Guild.Id}.{map}");

            await Collection.UpdateOneAsync(Herrscher, update);
        }
    }
}