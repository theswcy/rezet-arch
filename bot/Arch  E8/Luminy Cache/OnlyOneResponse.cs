using System.Runtime.Caching;



namespace Rezet.LuminyCache {
    public class RateLimitCahce {
        private readonly MemoryCache _cache;

        

        public RateLimitCahce() {
            _cache = MemoryCache.Default;
        }



        public void SaveUser(ulong Key) {
            var policy = new CacheItemPolicy {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(2)
            };
            _cache.Set(Key.ToString(),1 ,policy);
        }
    }
}