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

        public List<Report> Get()
        {
            return _reportService.Get();
        }
    }

    public class ListReportResponse
    {
        public List<Report> Reports { get; set; }
    }
}
