using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORed.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;

        public ModeratorController(
            IReportService reportService,
            IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult AllReports()
        {
            ViewBag.Reports = _reportService.Get();
            return View("AllReports.cshtml");
        }

        [HttpGet]
        public IActionResult MyReports(string id)
        {
            var user = _userService.GetByLogin(User.Identity.Name);
            ViewBag.Reports = _reportService.GetByModeratorId(user.Id);
            return View("AllReports.cshtml");
        }
    }
}
