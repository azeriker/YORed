using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using YORed.Domain.Enums;

namespace YORed.Domain.Entities
{
    public class Report
    {
        public Report()
        {
            Photos = new List<string>();
            CommentsHistory = new List<string>();
        }

        [BsonId]
        public string Id { get; set; }

        public List<string> Photos { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public string ModeratorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ReportStatus Status { get; set; }

        public List<string> CommentsHistory { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
