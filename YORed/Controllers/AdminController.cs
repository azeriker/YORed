using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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

        public AdminController(
            IConfiguration configuration,
            IUserService userService,
            IAdminService adminService,
            IUserRepository userRepository)
        {
            _configuration = configuration;
            _userService = userService;
            _adminService = adminService;
            _userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateUser(string phone, string role)
        {
            var result = _adminService.CreateUser(phone, Enum.Parse<UserRole>(role));
            return RedirectToAction("Index", "Admin", result ? "?result=success" : "?result=fail");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var users = _userRepository.Get();
            ViewBag.Users = users ?? new List<User>();
            return View();
        }
    }
}