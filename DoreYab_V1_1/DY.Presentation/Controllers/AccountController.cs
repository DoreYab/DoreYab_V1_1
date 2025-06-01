using DY.Application.Authentication.Models;
using DY.Application.Common.Interfaces;
using DY.Domain.Identity;
using DY.Presentation.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DY.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
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
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user == null)
                ViewBag.Message = "اگر ایمیل معتبر باشد، لینک بازیابی برای شما ارسال خواهد شد";
            return View();

            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var resetLink = Url.Action("ResetPassword", "Account", new
            {
                token = token,
                email = model.Email
            }, Request.Scheme);

            ViewBag.Message = $"لینک بازنشانی رمز: <a href='{resetLink}'>کلیک کنید</a>";
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
                return BadRequest("درخواست نامعبر است");

            return View(new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return RedirectToAction("ResetPasswordConfirmation");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
                return RedirectToAction("ResetPasswordConfirmation");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}