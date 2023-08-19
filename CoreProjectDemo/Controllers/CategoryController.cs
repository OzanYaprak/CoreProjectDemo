using Microsoft.AspNetCore.Mvc;

namespace CoreProjectDemo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
