using AutoMapper;
using Guide.Service.Dtos;
using Guide.Service.Models;
using Guide.Service.Settings;
using MongoDB.Driver;

namespace Guide.Service.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IMongoCollection<UserProfile> _userProfileCollection;
        private readonly IMapper _mapper;
        public UserProfileService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _userProfileCollection = database.GetCollection<UserProfile>(databaseSettings.UserProfileCollectionName);
            _mapper = mapper;
        }
        public async Task<UserProfileDto> CreateAsync(UserProfileCreateDto userProfileCreateDto)
        {
            var userProfile = _mapper.Map<UserProfile>(userProfileCreateDto);
            await _userProfileCollection.InsertOneAsync(userProfile);                
            return _mapper.Map<UserProfileDto>(userProfileCreateDto);
        }

        public async Task<bool> DeleteAsync(string uUId)
        {
            var userProfile = await _userProfileCollection.DeleteOneAsync<UserProfile>(x => x.UUID == uUId);
            return userProfile.DeletedCount > 0;
        }

        public async Task<List<UserProfileDto>> GetAllAsync()
        {
            var userProfiles = await _userProfileCollection.Find(userProfile => true).ToListAsync();
            return _mapper.Map<List<UserProfileDto>>(userProfiles);
        }

        public async Task<UserProfileDto> GetByIdAsync(string uUId)
        {
            var userProfile = await _userProfileCollection.Find<UserProfile>(x => x.UUID == uUId).FirstOrDefaultAsync();
            return _mapper.Map<UserProfileDto>(userProfile); ;
        }
    }
}
