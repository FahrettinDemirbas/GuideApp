using Guide.Service.Dtos;
using Guide.Service.Models;

namespace Guide.Service.Services
{
    public interface IUserContactService
    {
        Task<List<UserContactDto>> GetAllAsync();
        Task<UserContactDto> CreateAsync(UserContactCreateDto userContactCreateDto);
        Task<bool> DeleteAsync(string id);
        Task<UserContactDto> GetByIdAsync(string id);
    }
}
