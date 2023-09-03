using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            CacheViewModel model = new CacheViewModel();
            model.CacheTime = GetTime();
            return View(model);
        }

        public string GetTime()
        {
            var cacheKey = "TheTime";
            DateTime exitingTime;
            if(_memoryCache.TryGetValue(cacheKey, out exitingTime))
            {
                return "Fetch Time from Cache: "+ exitingTime.ToString();
            }
            else
            {
                exitingTime = DateTime.Now;
                _memoryCache.Set(cacheKey, exitingTime);
                return "Added to cache : " + exitingTime.ToString();
            }
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
    }
}
