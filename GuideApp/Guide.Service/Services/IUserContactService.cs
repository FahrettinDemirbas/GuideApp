using Guide.Service.Models;

namespace Guide.Service.Services
{
    public interface IUserContactService
    {
        Task<List<UserContact>> GetAllAsync();
        Task<UserContact> CreateAsync(UserContact userContact);
        Task<bool> DeleteAsync(string id);
        Task<UserContact> GetByIdAsync(string id);
    }
}
