using Microsoft.AspNetCore.Mvc;

using LoginProyect.Models;
using LoginProyect.Resources;
using LoginProyect.Services.Interfaces;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;



namespace LoginProyect.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(User model)
        {
            model.Password = Utilities.EncriptarClave(model.Password);

            User new_user = await _userService.SaveUser(model);

            if(new_user.IdUser > 0)
                return RedirectToAction("Login", "Login");

            ViewData["Message"] = "No se pudo crear el usuario";

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            User user_found = await _userService.GetUser(email, Utilities.EncriptarClave(password));

            if(user_found == null)
            {
                ViewData["Message"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user_found.UserName)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("index","Home");
        }
    }
}
