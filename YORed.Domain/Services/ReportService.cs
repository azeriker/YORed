using System;
using System.Collections.Generic;
using YORed.Domain.Entities;
using YORed.Domain.Enums;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUserService _userService;

        public ReportService(
            IReportRepository reportRepository,
            IUserService userService)
        {
            _reportRepository = reportRepository;
            _userService = userService;
        }

        public void Create(Report report, string userId)
        {
            report.UserId = userId;
            report.Date = DateTime.Now;
            report.Status = ReportStatus.New;

            _reportRepository.Create(report);
        }

        public Report Get(string id)
        {
            return _reportRepository.Get(id);
        }

        public List<Report> Get()
        {
            return _reportRepository.Get();
        }

        public List<Report> GetByModeratorId(string id)
        {
            return _reportRepository.GetByModeratorId(id);
        }

        public List<Report> GetByUserId(string id)
        {
            return _reportRepository.GetByUserId(id);
        }

        public void Update(Report report)
        {
            _reportRepository.Update(report);
        }

        public void AppointIfPossible(Report report, string login)
        {
            if (report.ModeratorId == null)
            {
                var user = _userService.GetByLogin(login);
                report.ModeratorId = user.Id;
            }
        }
    }
}
