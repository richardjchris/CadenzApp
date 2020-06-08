using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadenzApp.Models;
using CadenzApp.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace CadenzApp.Controllers
{
    [Authorize]
    public class HomeController : BaseViewController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TasksBusinessLogic BsLogic = new TasksBusinessLogic();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string Email, string Password, string Type)
        {
            if (!String.IsNullOrWhiteSpace(Email) && !String.IsNullOrWhiteSpace(Password) && !String.IsNullOrWhiteSpace(Type)) { 
                UserModel User = new UserModel();

                switch (Type)
                {
                    case "T":
                        User.Username = "Joseph Lloyd";
                        User.Email = "josephlloyd@gmail.com";
                        User.Role = "Tutor";
                        User.Picture = "joseph.png";
                        break;
                    case "S":
                        User.Username = "Anne Campbell";
                        User.Email = "annecanpbell@gmail.com";
                        User.Role = "Student";
                        User.Picture = "anne.png";
                        break;
                    default:
                        break;
                }

                var UserClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Username),
                    new Claim(ClaimTypes.Name, User.Username),
                    new Claim(ClaimTypes.Email, User.Email),
                    new Claim(ClaimTypes.Role, User.Role),
                    new Claim("Picture", User.Picture)
                };

                var UserIdentity = new ClaimsIdentity(UserClaim, "User Identity");
                var UserPrincipal = new ClaimsPrincipal(new[] { UserIdentity });

                HttpContext.SignInAsync(UserPrincipal);

                
                HttpContext.Session.SetString("Username", User.Username);
                HttpContext.Session.SetString("Email", User.Email);
                HttpContext.Session.SetString("Role", User.Role);
                HttpContext.Session.SetString("Picture", User.Picture);
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Please fill in all required details";

            return View();
        }

        /*public IActionResult Authenticate(UserModel User)
        {
            var UserClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, User.Username),
                    new Claim(ClaimTypes.Name, User.Username),
                    new Claim(ClaimTypes.Email, User.Email),
                    new Claim(ClaimTypes.Role, User.Role)
                };

            var UserIdentity = new ClaimsIdentity(UserClaim, "User Identity");
            var UserPrincipal = new ClaimsPrincipal(new[] { UserIdentity });
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };

            HttpContext.SignInAsync(UserPrincipal);

            return RedirectToAction("Index");
            *//*HttpContext.Session.SetString("Username", Username);
            HttpContext.Session.SetString("Email", Email);
            HttpContext.Session.SetString("Role", Role);*//*
        }*/

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            foreach (var cookie in Request.Cookies.Keys)
            {
                {
                    if (cookie == ".AspNetCore.Session")
                        Response.Cookies.Delete(cookie);
                }
            }

            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
