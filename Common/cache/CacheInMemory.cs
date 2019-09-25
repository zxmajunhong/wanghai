using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace Common
{
    public class CacheInMemory : OutputCacheProvider
    {
        private Dictionary<string, InMemoryOutputCacheItem> _cache = new Dictionary<string, InMemoryOutputCacheItem>();
        private readonly static object _syncLock = new object();
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            Set(key, entry, utcExpiry);
            return entry;
        }
        public override object Get(string key)
        {
            InMemoryOutputCacheItem item = null;
            if (_cache.TryGetValue(key, out item))
            {
                if (item.UtcExpiry < DateTime.UtcNow)
                {
                    Remove(key);
                    return null;
                }
                return item.Value;
            }
            return null;
        }
        public override void Remove(string key)
        {
            InMemoryOutputCacheItem item = null;
            if (_cache.TryGetValue(key, out item))
            {
                _cache.Remove(key);
            }
        }
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            var item = new InMemoryOutputCacheItem(entry, utcExpiry);
            lock (_syncLock)
            {
                if (_cache.ContainsKey(key))
                {
                    _cache[key] = item;
                }
                else
                {
                    _cache.Add(key, item);
                }
            }
        }
    }
    public class InMemoryOutputCacheItem
    {
        public DateTime UtcExpiry { get; set; }
        public object Value { get; set; }

        public InMemoryOutputCacheItem(object value, DateTime utcExpiry)
        {
            Value = value;
            UtcExpiry = utcExpiry;
        }
    }


}
