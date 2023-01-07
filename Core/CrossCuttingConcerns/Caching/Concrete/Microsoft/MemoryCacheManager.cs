using Core.CrossCuttingConcerns.Caching.Abstract;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Concrete.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
        // microsoftun kendi yapısından gelen bir interface
        IMemoryCache _memoryCache;

        // constructor da vermek injectionu cozmez
        // bu zincir api-> business-> dataAcces arasında gerceklesiyor.
        // Biz Cache'i aspect olara kullanacagiz burada boyle vermek islemez.
        // O yuzden yazdigimiz service'de injectionu cozeceziz

        public MemoryCacheManager()
        {
            // Yazdigimiz tooldan aldik karsiligini karsiligini ise DependencyResolver da CoreModule Yazmistik
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);    
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            // bana degeri vermene gerek yok dedik 
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
             _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
