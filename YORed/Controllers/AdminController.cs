using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORed.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AdminController(IConfiguration configuration, IUserService userService, IAdminService adminService, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _adminService = adminService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            var adminLogin = _configuration.GetSection("adminLogin").Value;
            var adminPassword = _configuration.GetSection("adminPassword").Value;
            if (login == adminLogin && password == adminPassword)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
                };
                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }
            return RedirectToAction("Index", "Admin");

        }

        [HttpPost]
        public IActionResult CreateUser(string phone, string type)
        {
            var result = _adminService.CreateUser(phone, Enum.Parse<UserRole>(type));
            return RedirectToAction("Index", "Admin", result ? "?result=success" : "?result=fail");
        }


        public IActionResult Index()
        {
            var users = _userRepository.Get();
            ViewBag.Users = users ?? new List<User>();
            return View();
        }
    }
}