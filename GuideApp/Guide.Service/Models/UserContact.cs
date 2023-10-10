using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static Guide.Service.Enums;

namespace Guide.Service.Models
{
    public class UserContact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public ContactTypes InformationType { get; set; }
        public string InformationDetail { get; set; }
        public string ParentId { get; set; }
    }
}
