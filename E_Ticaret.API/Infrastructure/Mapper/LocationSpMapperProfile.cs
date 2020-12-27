using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.Location;
using E_Ticaret.Model.Entities;

namespace E_Ticaret.API.Infrastructure.Mapper
{
    public class LocationSpMapperProfile : Profile
    {
        public LocationSpMapperProfile()
        {
            CreateMap<LocationSp, LocationRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LocationSp, LocationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
