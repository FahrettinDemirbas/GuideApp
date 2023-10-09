using Guide.Service.Models;
using Guide.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserContactController : ControllerBase
    {
        private readonly IUserContactService _userContactService;

        public UserContactController(IUserContactService userContactService)
        {
            _userContactService = userContactService;
        }
        [HttpGet]
        public async Task<List<UserContact>> GetAll()
        {
            var categories = await _userContactService.GetAllAsync();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<UserContact> GetById(string id)
        {
            var response = await _userContactService.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        public async Task<UserContact> Create(UserContact userContact)
        {
            var response = await _userContactService.CreateAsync(userContact);
            return response;
        }

        [HttpPost("{id}")]
        public async Task<bool> Delete(string id)
        {
            var response = await _userContactService.DeleteAsync(id);
            return response;
        }
    }
}
