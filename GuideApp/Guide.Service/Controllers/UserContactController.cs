using Guide.Service.Dtos;
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
        public async Task<List<UserContactDto>> GetAll()
        {
            var categories = await _userContactService.GetAllAsync();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<UserContactDto> GetById(string id)
        {
            var response = await _userContactService.GetByIdAsync(id);
            return response;
        }

        [HttpPost]
        public async Task<UserContactDto> Create(UserContactCreateDto userContactCreateDto)
        {
            var response = await _userContactService.CreateAsync(userContactCreateDto);
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
