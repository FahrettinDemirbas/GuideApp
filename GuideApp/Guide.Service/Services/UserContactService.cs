using AutoMapper;
using Guide.Service.Dtos;
using Guide.Service.Models;
using Guide.Service.Settings;
using MongoDB.Driver;

namespace Guide.Service.Services
{
    public class UserContactService : IUserContactService
    {
        private readonly IMongoCollection<UserContact> _userContactCollection;
        private readonly IMapper _mapper;
        public UserContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _userContactCollection = database.GetCollection<UserContact>(databaseSettings.UserContactCollectionName);
            _mapper = mapper;
        }
        public async Task<UserContactDto> CreateAsync(UserContactCreateDto userContactCreateDto)
        {
            var userContact = _mapper.Map<UserContact>(userContactCreateDto);
            await _userContactCollection.InsertOneAsync(userContact);
            return _mapper.Map<UserContactDto>(userContactCreateDto);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var userContact = await _userContactCollection.DeleteOneAsync<UserContact>(x => x.Id == id);
            return userContact.DeletedCount > 0;
        }

        public async Task<List<UserContactDto>> GetAllAsync()
        {
            var userContacts = await _userContactCollection.Find(userContact => true).ToListAsync();            
            return _mapper.Map<List<UserContactDto>>(userContacts);
        }

        public async Task<UserContactDto> GetByIdAsync(string id)
        {
            var userContact = await _userContactCollection.Find<UserContact>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserContactDto>(userContact); ;
        }
    }
}
