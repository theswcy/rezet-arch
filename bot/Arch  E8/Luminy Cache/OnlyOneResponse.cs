using System.Runtime.Caching;



namespace Rezet.LuminyCache {
    public class RateLimitCahce {
        private readonly MemoryCache _cache;

        

        public RateLimitCahce() {
            _cache = MemoryCache.Default;
        }



        public async Task<bool> VerifyUser(ulong Key) {
            if (_cache.Get(Key.ToString()) != null) {
                await Task.CompletedTask;
                return false;
            }
            var policy = new CacheItemPolicy {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(2)
            };
            _cache.Set(Key.ToString(),1 ,policy);
            await Task.CompletedTask;
            return true;
        }
    }
}