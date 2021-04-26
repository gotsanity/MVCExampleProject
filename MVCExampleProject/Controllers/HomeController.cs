using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCExampleProject.Models;
using MVCExampleProject.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICatService _cats;

        public HomeController(ILogger<HomeController> logger, ICatService catService)
        {
            _logger = logger;
            _cats = catService;
        }

        public async Task<IActionResult> Index()
        {
            CatResponse cat = await _cats.GetRandomCat();

            _logger.LogInformation(cat.url);

            ViewBag.cat = cat;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
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
