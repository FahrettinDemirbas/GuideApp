using Guide.Service.Models;
using Guide.Service.Settings;
using MongoDB.Driver;

namespace Guide.Service.Services
{
    public class UserContactService : IUserContactService
    {
        private readonly IMongoCollection<UserContact> _userContactCollection;

        public UserContactService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _userContactCollection = database.GetCollection<UserContact>(databaseSettings.UserContactCollectionName);
        }
        public async Task<UserContact> CreateAsync(UserContact userContact)
        {
            await _userContactCollection.InsertOneAsync(userContact);
            return userContact;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var userContact = await _userContactCollection.DeleteOneAsync<UserContact>(x => x.Id == id);
            return userContact.DeletedCount > 0;
        }

        public async Task<List<UserContact>> GetAllAsync()
        {
            var userContacts = await _userContactCollection.Find(userContact => true).ToListAsync();
            return userContacts;
        }

        public async Task<UserContact> GetByIdAsync(string id)
        {
            var userContact = await _userContactCollection.Find<UserContact>(x => x.Id == id).FirstOrDefaultAsync();
            return userContact;
        }
    }
}
