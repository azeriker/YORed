using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORedApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IUserService _userService;

        public ReportsController(
            IReportService reportService,
            IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public void Create([FromBody]Report report)
        {
            _reportService.Create(report, User.Identity.Name);
        }

        [HttpGet]
        public List<Report> Get()
        {
            var reports = _reportService.Get();
            reports.Reverse();
            return reports;
        }

        [HttpGet]
        public Report GetById(string id)
        {
            return _reportService.Get(id);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public List<Report> GetByUser()
        {
            var reports = _reportService.GetByUserId(User.Identity.Name);
            reports.Reverse();
            return reports;
        }
    }
}
