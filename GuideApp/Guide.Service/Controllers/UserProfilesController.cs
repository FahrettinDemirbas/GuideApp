﻿using Guide.Service.Dtos;
using Guide.Service.Models;
using Guide.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Guide.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet]                          
        public async Task<List<UserProfileDto>> GetAll()
        {
            var categories = await _userProfileService.GetAllAsync();
            return categories;
        }

        [HttpGet("{uUId}")]
        public async Task<UserProfileDto> GetById(string uUId)
        {
            var response = await _userProfileService.GetByIdAsync(uUId);
            return response;
        }

        [HttpPost("Create")]
        public async Task<UserProfileDto> Create(UserProfileCreateDto userProfileCreateDto)
        {
            var response = await _userProfileService.CreateAsync(userProfileCreateDto);
            return response;
        }

        [HttpPost("{uUId}")]
        public async Task<bool> Delete(string uUId)
        {
            var response = await _userProfileService.DeleteAsync(uUId);
            return response;
        }
    }
}
