﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using W9.InTheOven.Models;

namespace W9.InTheOven.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login([FromQuery] string? returnUrl = "/") {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl) {
            var claim = new ClaimsPrincipal(
                new ClaimsIdentity([new Claim(ClaimTypes.Name, "nello")],
                CookieAuthenticationDefaults.AuthenticationScheme));
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim);
            return Redirect(returnUrl);
        }
    }
}
