using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement.Mvc;

namespace AppConfigMeetupDemo.Controllers
{
    [FeatureGate("Sales")]
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
