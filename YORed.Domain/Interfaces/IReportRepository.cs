using System.Collections.Generic;
using YORed.Domain.Entities;

namespace YORed.Domain.Interfaces
{
    public interface IReportRepository
    {
        void Create(Report report);

        Report Get(string id);

        List<Report> GetByModeratorId(string id);

        List<Report> GetByUserId(string id);

        void Update(Report report);
    }
}
