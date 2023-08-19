using CoreProjectDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email
            };

            if (model.Password == model.ConfirmPassword)
            {
                var registerResult = await _userManager.CreateAsync(appUser, model.Password);

                if (registerResult.Succeeded) { return RedirectToAction("Index", "Login"); }
                else
                {
                    foreach (var errors in registerResult.Errors)
                    {
                        ModelState.AddModelError("", errors.Description);
                    }
                }
            }

            return View(model);
        }
    }
}
