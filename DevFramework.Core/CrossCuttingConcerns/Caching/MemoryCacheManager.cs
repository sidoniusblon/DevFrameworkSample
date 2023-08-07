using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    [Serializable]
    public class MemoryCacheManager:ICacheManager
    {
        protected ObjectCache Cache { get { return MemoryCache.Default; } }

        public void Add(string key, object data, int cachetime=60)
        {
            if (data == null) return;
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cachetime) };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }       
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool isAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string path)
        {
            var regex = new Regex(path, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
