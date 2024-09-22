using Company.Data.Entities;
using Company.Services.Helper;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _user;
        private readonly SignInManager<ApplicationUser> _signInMangager;

        public AccountController(UserManager<ApplicationUser> user,
                                SignInManager<ApplicationUser> signInMangager)
        {
            _user = user;
            _signInMangager = signInMangager;
        }
        #region SignUp
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };

                var result = await _user.CreateAsync(user, input.Password);
                if (result.Succeeded)
                    return RedirectToAction("Login");
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(input);
        }
        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    if (await _user.CheckPasswordAsync(user, input.Password))
                    {
                        var result = await _signInMangager.PasswordSignInAsync(user, input.Password, input.IsAgree, true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("index", "Home");
                        }
                    }
                }
                ModelState.AddModelError("", "Incorrect Email Or Password");
                return View(input);
            }
            return View(input);

        }
        #endregion
        #region Signout
        public new async Task<IActionResult> SignOut()
        {
            await _signInMangager.SignOutAsync();
            return RedirectToAction(nameof(Login));   
        }
        #endregion
        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.FindByEmailAsync(input.Email);
                if(user is not null)
                {
                    var token = await _user.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new {input.Email,Token = token},Request.Scheme);
                    var email = new Email
                    {
                        Body = url,
                        Subject = "Reset Password",
                        To = input.Email,
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
            }
            return View();
        }
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        public IActionResult ResetPassword(string Email,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    var result = await _user.ResetPasswordAsync(user, input.Token, input.Password);
                    if (result.Succeeded) 
                        return RedirectToAction(nameof(Login));
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
                }
            }
            return View(input);
        }
        #endregion
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

