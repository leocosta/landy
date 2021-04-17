using AutoMapper;
using Landy.Services.Identity.Core.Dtos;
using Landy.Services.Identity.Core.Entities;

namespace Landy.Services.Identity.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}