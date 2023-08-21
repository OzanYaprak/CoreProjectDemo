using CoreProjectDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreProjectDemo.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var loginUser = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel userEditViewModel = new UserEditViewModel();

            userEditViewModel.Name = loginUser.Name;
            userEditViewModel.Surname = loginUser.Surname;
            userEditViewModel.Email = loginUser.Email;
            userEditViewModel.Gender = loginUser.Gender;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var loginUser = await _userManager.FindByNameAsync(User.Identity.Name);

            loginUser.Name = model.Name;
            loginUser.Surname = model.Surname;
            loginUser.Email = model.Email;
            loginUser.Gender = model.Gender;
            loginUser.PasswordHash = _userManager.PasswordHasher.HashPassword(loginUser, model.Password);

            var userUpdateResult = await _userManager.UpdateAsync(loginUser);

            if (userUpdateResult.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var errors in userUpdateResult.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }

            return View();
        }

    }
}
