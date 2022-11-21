using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using mvc.Entities.enums;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginActionAsync(UserData data)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(data.Password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            data.Password = hash;

            var userRep = new UserRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

            UserData userData = userRep.GetUserWithLogin(data.Login);
            Console.WriteLine(userData);
            if (userData != null)
            {
                if (userData.Password == data.Password)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, userData.Login),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, Enum.GetName(typeof(Role), userData.Role))
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Coockie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultNameClaimType);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Main");
        }

        public void Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Redirect("/");
        }

        [HttpPost]
        public IActionResult RegisterAction(UserData data)
        {
            var userRep = new UserRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

            if (data.Login.Length < 2)
            {
                ModelState.AddModelError("Name", "Name must be from 3 letters!");
            }

            if (data.Login.Length > 50)
            {
                ModelState.AddModelError("Name", "Name must be smaller then 50 letters!");
            }

            if (userRep.CheckIsUserRegisterd(data.Login))
            {
                ModelState.AddModelError("loginError", "This login is used, try another");
            }

            if (ModelState.IsValid)
            {
                var crypt = new SHA256Managed();
                string hash = String.Empty;

                byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(data.Password));
                foreach (byte theByte in crypto)
                {
                    hash += theByte.ToString("x2");
                }
                data.Password = hash;

                data.DateOfRegister = DateTime.Now;
                bool result = userRep.AddNewUserToDataBase(data);

                return RedirectToAction("Login", "User");
            }

            string errors = string.Join(" ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            ViewResult viewResult = View("Register", new UserViewModel(errors));
            return viewResult;
        }
    
        
    
    }
}
