﻿using System.Collections.Generic;
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
        public void Create(Report report)
        {
            var user = _userService.GetByLogin(User.Identity.Name);
            _reportService.Create(report, user.Id);
        }

        public List<Report> Get()
        {
            return _reportService.Get();
        }

        public Report GetById(string id)
        {
            return _reportService.Get(id);
        }

        [Authorize(Roles = "User")]
        public List<Report> GetByUser()
        {
            var user = _userService.GetByLogin(User.Identity.Name);
            return _reportService.GetByUserId(user.Id);
        }
    }
}