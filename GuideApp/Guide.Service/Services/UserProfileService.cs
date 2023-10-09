using AutoMapper;
using Guide.Service.Models;
using Guide.Service.Settings;
using MongoDB.Driver;

namespace Guide.Service.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IMongoCollection<UserProfile> _userProfileCollection;

        public UserProfileService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _userProfileCollection = database.GetCollection<UserProfile>(databaseSettings.UserProfileCollectionName);
        }
        public async Task<UserProfile> CreateAsync(UserProfile userProfile)
        {
            await _userProfileCollection.InsertOneAsync(userProfile);
            return userProfile;
        }

        public async Task<bool> DeleteAsync(string uUId)
        {
            var userProfile = await _userProfileCollection.DeleteOneAsync<UserProfile>(x => x.UUID == uUId);
            return userProfile.DeletedCount > 0;
        }

        public async Task<List<UserProfile>> GetAllAsync()
        {
            var userProfiles = await _userProfileCollection.Find(userProfile => true).ToListAsync();
            return userProfiles;
        }

        public async Task<UserProfile> GetByIdAsync(string uUId)
        {
            var userProfile = await _userProfileCollection.Find<UserProfile>(x => x.UUID == uUId).FirstOrDefaultAsync();
            return userProfile;
        }
    }
}
