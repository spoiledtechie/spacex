using ServiceStack.Redis;
using System;

namespace SpaceX.Library.Cache
{
    /// <summary>
    /// cache manager used for Redis
    /// </summary>
    public class RedisCacheManager
    {
        /// <summary>
        /// Gets or sets the redis client manager.
        /// </summary>
        /// <value>
        /// The redis client manager.
        /// </value>
        protected IRedisClient RedisClientManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisBigAppRepositoryService" /> class.
        /// </summary>
        /// <param name="redisServerConnectionString">The redis server connection string.</param>
        public RedisCacheManager(string redisServerConnectionString)
        {
            //var redisManager = new PooledRedisClientManager(1, redisServerConnectionString);
            //RedisClientManager = redisManager.GetClient();
        }

        /// <summary>
        /// constructor
        /// </summary>
        public RedisCacheManager()
        {
            //var redisManager = new PooledRedisClientManager(1, "REDISCONNECTIONSTRING");
            //RedisClientManager = redisManager.GetClient();
        }

        /// <summary>
        /// clears the redis cache.
        /// </summary>
        public void ClearCache()
        {
            //RedisClientManager.FlushDb();
        }

        /// <summary>
        /// gets the cache by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetCache<T>(string id)
        {
            //var redisCache = RedisClientManager.As<T>();
            //var item = redisCache.GetValue(id);

            //return item;

            return default(T);

        }
        /// <summary>
        /// adds to the cache by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheItem"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public T AddCache<T>(T cacheItem, string id) where T : new()
        {
            //var redisCache = RedisClientManager.As<T>();

            //redisCache.SetValue(id, cacheItem);
            //return cacheItem;

            return default(T);
        }
        /// <summary>
        /// adds cache by id and sets an expiration time.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheItem"></param>
        /// <param name="id"></param>
        /// <param name="expireIn"></param>
        /// <returns></returns>
        public T AddCache<T>(T cacheItem, string id, TimeSpan expireIn) where T : new()
        {
            //var redisCache = RedisClientManager.As<T>();

            //redisCache.GetValue(id);
            //return cacheItem;

            return default(T);
        }

        public void DeleteCache<T>(string id) where T : new()
        {
            //var redisCache = RedisClientManager.As<T>();

            //redisCache.DeleteById(id);

        }
    }
}
