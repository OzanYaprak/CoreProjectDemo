using Microsoft.AspNetCore.Mvc;

namespace CoreProjectDemo.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
