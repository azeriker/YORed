using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using YORed.Domain.Interfaces;

namespace YORed.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(
            IUserService userService,
            IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            if(!_userRepository.Exists(login, password))
                return Login();

            var user = _userService.GetByLogin(login);

            if (login == user.Login.Phone && password == user.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
                };

                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }

            return RedirectToAction("Index", user.Role.ToString());
        }
    }
}
