using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Noemi_More_WeekMVC.Core.Interfaces;
using Noemi_More_WeekMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL; 
        public UtentiController(IBusinessLayer bl)
        {
            BL = bl; 
        }




        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UtenteLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }






        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteLoginViewModel utenteLoginViewModel)
        {
            if (utenteLoginViewModel == null)
            {
                return View();
            }

            var utente = BL.GetAccount(utenteLoginViewModel.Email);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteLoginViewModel.Password)
                {
                    

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Nome),
                        new Claim(ClaimTypes._Ruolo, utente.Ruolo.ToString())
                    };

                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1), // logout dopo un'ora di inattività
                        RedirectUri = utenteLoginViewModel.ReturnUrl
                    };
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(utenteLoginViewModel.Password), "Password errata");
                    return View(utenteLoginViewModel);
                }
            }
            
            return View();
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden() => View();





    }
}
