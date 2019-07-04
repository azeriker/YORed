using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORed.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public void Create([FromBody] Report report)
        {
            _reportService.Create(report);
        }

        public List<Report> Get()
        {
            return _reportService.Get();
        }

        public Report GetById(string id)
        {
            return _reportService.Get(id);
        }

        public List<Report> GetByUserId(string id)
        {
            return _reportService.GetByUserId(id);
        }
    }
}
