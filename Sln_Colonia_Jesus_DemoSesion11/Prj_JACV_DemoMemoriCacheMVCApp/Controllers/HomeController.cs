﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Prj_JACV_DemoMemoriCacheMVCApp.Models;
using System.Diagnostics;

namespace Prj_JACV_DemoMemoriCacheMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache; 

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CacheTryGetValueSet()
        {
            DateTime cacheEntry;
            if(!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                cacheEntry = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5));
                _cache.Set(CacheKeys.Entry, cacheEntryOptions);
            }
            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGet()
        {
            var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
            return View("Cache", cacheEntry);
        }

        public IActionResult CacheRemove()
        {
            _cache.Remove(CacheKeys.Entry);
            return View("Cache", new DateTime(1990,1,1));
        }

        public IActionResult CacheGetOrCreate()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry=>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(5);
                return DateTime.Now;
            });
            return View("Cache", cacheEntry);
        }

        public async Task<IActionResult> CacheGetOrCreateAsynchronous()
        {
            var cacheEntry = await _cache.GetOrCreateAsync(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(5);
                return Task.FromResult(DateTime.Now);
            });
            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGetOrCreateAbs()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                return DateTime.Now;
            });
            return View("Cache", cacheEntry);
        }

        public IActionResult CacheGetOrCreateAbsSliding()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromSeconds(3));
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                return DateTime.Now;
            });
            return View("Cache", cacheEntry);
        }
    }
}