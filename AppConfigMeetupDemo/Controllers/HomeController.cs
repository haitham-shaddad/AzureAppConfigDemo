using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppConfigMeetupDemo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;

namespace AppConfigMeetupDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager featureManager;
        public HomeController(IFeatureManager featureManager, IConfiguration configuration, ILogger<HomeController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            this.featureManager = featureManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.AppTitle = _configuration["appsettings:AppTitle"];
            ViewBag.ShowSalesLink = await featureManager.IsEnabledAsync("Sales");
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
    }
}
