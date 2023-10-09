using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Guide.Service.Models
{
    public class UserContact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string InformationType { get; set; }
        public string InformationDetail { get; set; }
        public string ParentId { get; set; }
    }
}
