﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotifyMs.Admin.Models;
using SpotifyMs.Aplication.Admin;
using System.Security.Claims;

namespace SpotifyMs.Admin.Controllers
{
    public class AccountController : Controller
    {
        private UsuarioAdminService usuarioAdminService;

        public AccountController(UsuarioAdminService usuarioAdminService)
        {
            this.usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid == false)
                return View();

            var user = this.usuarioAdminService.Authenticate(request.Email, request.Senha);

            if (user == null)
            {
                ModelState.AddModelError("login_failed", "Email ou senha incorreta");
                return View();
            }

            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nome));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                                          new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
