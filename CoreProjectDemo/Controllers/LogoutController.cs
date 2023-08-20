using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();

            return View();
        }
    }
}
