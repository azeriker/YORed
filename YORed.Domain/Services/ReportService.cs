using System.Collections.Generic;
using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public void Create(Report report)
        {
            _reportRepository.Create(report);
        }

        public Report Get(string id)
        {
            return _reportRepository.Get(id);
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
    }
}
