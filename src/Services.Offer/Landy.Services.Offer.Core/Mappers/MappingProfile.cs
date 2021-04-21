using AutoMapper;
using Landy.Domain.ValueObjects;
using Landy.Services.Offer.Core.Dtos;

namespace Landy.Services.Offer.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Offer, OfferDto>().ReverseMap();
            CreateMap<Entities.Image, ImageDto>().ReverseMap();
            CreateMap<Money, MoneyDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
