using CoreProjectDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
            /* 
             * Access Fail Count Default Değeri 5'dir.
             * Default Locklanma Süresi 5 Dk. 
             */

            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

                if (loginResult.Succeeded) { return RedirectToAction("Index", "Home"); }
                else { ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış"); }
            }

            return View();
        }

        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
