using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static Guide.Service.Enums;

namespace Guide.Service.Models
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime RequestDate { get; set; }
        public ReportStatus ReportStatu { get; set; }
    }
}
