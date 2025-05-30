using DY.Application.Authentication.Models;
using DY.Application.Common.Interfaces;
using DY.Presentation.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DY.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
            if (!ModelState.IsValid)
                return View(registerView);

            try
            {
                var requrst = new RegisterRequest
                {
                    FullName = registerView.FullName,
                    Email = registerView.Email,
                    Password = registerView.Password,
                };

                var result = await _authService.RegisterAsync(requrst);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(registerView);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            if (!ModelState.IsValid)
                return View(loginView);

            try
            {
                var request = new LoginRequest
                {
                    Email = loginView.Email,
                    Password = loginView.Password,
                };

                var result = await _authService.LoginAsync(request);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(loginView);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public  IActionResult ForgetPassword()
        {
            return View();
        }

    }
}

