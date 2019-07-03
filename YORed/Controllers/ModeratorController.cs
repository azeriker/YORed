using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json.Bson;
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

        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public IActionResult Index()
        {
          ViewBag.Reports = _reportService.Get();
            return View("Index");
        }

        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public IActionResult MyReports()
        {
            var user = GetCurrentUser();
            ViewBag.Reports = _reportService.GetByModeratorId(user.Id);
            return View("MyReports");
        }

        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public IActionResult Report(string id)
        {
            var report = _reportService.Get(id);
            var user = GetCurrentUser();
            ViewBag.UserId = user.Id;
            ViewBag.Report = report;
            return View("Report");
        }

        [HttpPost]
        public IActionResult UpdateReport(Report report)
        {
            _reportService.AppointIfPossible(report, User.Identity.Name);
            _reportService.Update(report);
            return Report(report.Id);
        }

        private User GetCurrentUser()
        {
            return _userService.GetByLogin(User.Identity.Name);
        }
    }
}
