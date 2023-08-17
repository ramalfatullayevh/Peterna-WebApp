using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Peterna.Migrations;
using Peterna.Models;
using Peterna.ViewModels;

namespace Peterna.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            AppUser user = await _userManager.FindByNameAsync(registerVM.UserName);
            if (user is not null)
            {
                ModelState.AddModelError("UserName", "Bele istifadeci var");
                return View(registerVM);
            }
            user = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
                Email = registerVM.Email,

            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();

            }

            await _signInManager.SignInAsync(user, true);
            return RedirectToAction(nameof(Login));

        }

        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string? ReturnUrl)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", "Login or password is wrong");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);
            if (!result.Succeeded)
            {

                ModelState.AddModelError("", "Login or password is wrong");
                return View();
            }
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
