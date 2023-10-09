using Guide.Service.Dtos;

namespace Guide.Service.Services
{
    public interface IUserProfileService
    {
        Task<List<UserProfileDto>> GetAllAsync();
        Task<UserProfileDto> CreateAsync(UserProfileDto userProfileDto);
        Task<UserProfileDto> DeleteAsync(UserProfileDto userProfileDto);
        Task<UserProfileDto> GetByIdAsync(string uUId);
    }
}
