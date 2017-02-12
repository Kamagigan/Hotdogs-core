using HotDogsWeb.Models;
using HotDogsWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotDogsWeb.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<HotDogUser> _signInManager;

        public AuthController(SignInManager<HotDogUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("favorites", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username ou mot de passe incorrect.");
                }
            }

            return View();
        }

        public async Task<IActionResult> logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
