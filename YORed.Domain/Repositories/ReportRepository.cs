using System.Collections.Generic;
using MongoDB.Driver;
using YORed.Domain.Entities;
using YORed.Domain.Interfaces;

namespace YORed.Domain.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private IMongoCollection<Report> _collection;

        public ReportRepository(MongoContext context)
        {
            _collection = context.Reports;
        }

        public void Create(Report report)
        {
            _collection.InsertOne(report);
        }

        public Report Get(string id)
        {
            return _collection.Find(i => i.Id == id).FirstOrDefault();
        }

        public List<Report> Get()
        {
            return _collection.Find(_ => true).ToList();
        }

        public List<Report> GetByModeratorId(string id)
        {
            return _collection.Find(i => i.ModeratorId == id).ToList();
        }

        public List<Report> GetByUserId(string id)
        {
            return _collection.Find(i => i.UserId == id).ToList();
        }

        public void Update(Report report)
        {
            var update = Builders<Report>.Update
                .Set(i => i.Comment, report.Comment)
                .Set(i => i.Description, report.Description)
                .Set(i => i.Title, report.Title)
                .Set(i => i.Status, report.Status);
                    
            _collection.UpdateOne(i => i.Id == report.Id, update);
        }
    }
}
