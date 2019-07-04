using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using YORed.Domain.Enums;

namespace YORed.Domain.Entities
{
    public class Report
    {
        public Report()
        {
            Photos = new List<string>();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public List<string> Photos { get; set; }

        public DateTime? Date { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ModeratorId { get; set; }

        public string Description { get; set; }

        public ReportStatus? Status { get; set; }

        public string Comment { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
