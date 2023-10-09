using Guide.Service.Models;

namespace Guide.Service.Services
{
    public interface IUserProfileService
    {
        Task<List<UserProfile>> GetAllAsync();
        Task<UserProfile> CreateAsync(UserProfile userProfile);
        Task<bool> DeleteAsync(string uUId);
        Task<UserProfile> GetByIdAsync(string uUId);
    }
}
