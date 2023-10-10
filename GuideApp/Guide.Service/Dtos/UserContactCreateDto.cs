using static Guide.Service.Enums;

namespace Guide.Service.Dtos
{
    public class UserContactCreateDto
    {
        public ContactTypes InformationType { get; set; }
        public string InformationDetail { get; set; }
        public string ParentId { get; set; }
    }
}
