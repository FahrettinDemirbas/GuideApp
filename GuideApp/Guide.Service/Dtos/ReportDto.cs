using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static Guide.Service.Enums;

namespace Guide.Service.Dtos
{
    public class ReportDto
    {
        public string UUID { get; set; }
        public DateTime Request { get; set; }
        public string ReportStatu { get; set; }
    }
}
