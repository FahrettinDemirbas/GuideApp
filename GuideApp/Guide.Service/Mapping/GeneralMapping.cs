using AutoMapper;
using Guide.Service.Dtos;
using Guide.Service.Models;
using MongoDB.Driver.Core.Misc;

namespace Guide.Service.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserContact, UserContactCreateDto>().ReverseMap();
            CreateMap<UserContact, UserContactDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileCreateDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        }
    }
}

