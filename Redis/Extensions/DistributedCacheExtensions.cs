using System;
using Microsoft.Extensions.Caching.Distributed;

namespace Redis.Extensions
{
    public static class DistributedCacheExtension
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, 
                                                    string RecordId, 
                                                    T data, 
                                                    TimeSpan? absoluteExpireTime = null,
                                                    TimeSpan? unusedExpireTime = null)
        {
            
        }
    }
}