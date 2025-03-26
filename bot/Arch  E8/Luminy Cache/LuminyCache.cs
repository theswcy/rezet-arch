using System.Runtime.Caching;
using MongoDB.Bson;
using DSharpPlus;



namespace Rezet.LuminyCache {
    public class GuildCache {
        // ========== SAVE THE GUILD:
        public static void SaveGuild(DiscordClient client, string GuildId, BsonDocument Structure) {
            var policy = new CacheItemPolicy {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(24)
            };


            if (client.ShardId == 0) {
                var LumiCache = new GuildCache_shard_0();
                LumiCache.CacheShard0.Add(GuildId, Structure, policy);
            } else if (client.ShardId == 1) {
                var LumiCache = new GuildCache_shard_1();
                LumiCache.CacheShard1.Add(GuildId, Structure, policy);
            } else if (client.ShardId == 2) {
                var LumiCache = new GuildCache_shard_2();
                LumiCache.CacheShard2.Add(GuildId, Structure, policy);
            }
        }
        // ========== GET THE GUILD:
        public static BsonDocument? GetGuild(DiscordClient client, string GuildId) {
            if (client.ShardId == 0) {
                var LumiCache = new GuildCache_shard_0();
                return LumiCache.CacheShard0.Get(GuildId) as BsonDocument;
            } else if (client.ShardId == 1) {
                var LumiCache = new GuildCache_shard_1();
                return LumiCache.CacheShard1.Get(GuildId) as BsonDocument;
            } else if (client.ShardId == 2) {
                var LumiCache = new GuildCache_shard_2();
                return LumiCache.CacheShard2.Get(GuildId) as BsonDocument;
            } else {
                return null;
            }
        }
        // ========== REMOVE THE GUILD:
        public static void RemoveGuild(DiscordClient client, string GuildId) {
            if (client.ShardId == 0) {
                var LumiCache = new GuildCache_shard_0();
                LumiCache.CacheShard0.Remove(GuildId);
            } else if (client.ShardId == 1) {
                var LumiCache = new GuildCache_shard_1();
                LumiCache.CacheShard1.Remove(GuildId);
            } else if (client.ShardId == 2) {
                var LumiCache = new GuildCache_shard_2();
                LumiCache.CacheShard2.Remove(GuildId);
            }
        }




        public class GuildCache_shard_0 {
            public MemoryCache CacheShard0;
            public GuildCache_shard_0() {
                CacheShard0 = MemoryCache.Default;
            }
        }
        public class GuildCache_shard_1 {
            public MemoryCache CacheShard1;
            public GuildCache_shard_1() {
                CacheShard1 = MemoryCache.Default;
            }
        }
        public class GuildCache_shard_2 {
            public MemoryCache CacheShard2;
            public GuildCache_shard_2() {
                CacheShard2 = MemoryCache.Default;
            }
        }
    }
}