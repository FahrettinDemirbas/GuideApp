using Guide.Service.Dtos;
using Guide.Service.Models;

namespace Guide.Service.Services
{
    public interface IUserProfileService
    {
        Task<List<UserProfileDto>> GetAllAsync();
        Task<UserProfileDto> CreateAsync(UserProfileCreateDto userProfileCreateDto);
        Task<bool> DeleteAsync(string uUId);
        Task<UserProfileDto> GetByIdAsync(string uUId);
    }
}
