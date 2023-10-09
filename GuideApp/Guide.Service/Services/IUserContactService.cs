using Guide.Service.Dtos;

namespace Guide.Service.Services
{
    public interface IUserContactService
    {
        Task<List<UserContactDto>> GetAllAsync();
        Task<UserContactDto> CreateAsync(UserContactDto userContactDto);
        Task<UserContactDto> DeleteAsync(UserContactDto userContactDto);
        Task<UserContactDto> GetByIdAsync(string uUId);
    }
}
