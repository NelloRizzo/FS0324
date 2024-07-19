﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using W7.D3.BusinessLayer;
using W7.D3.WebAuthenticationSample.Models;

namespace W7.D3.WebAuthenticationSample.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService service;
        public AccountController(IAccountService service) {
            this.service = service;
        }
        [AllowAnonymous]
        public IActionResult Login([FromQuery] string returnUrl = "/") {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model) {
            var u = service.Login(model.Username, model.Password);
            if (u != null) {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, u.Username),
                    new Claim(Claims.Birthday, u.Birthday.ToShortDateString())
                };
                u.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            }

            return Redirect(ViewData["ReturnUrl"]?.ToString() ?? Url.Action("Index", "Home")!);
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
