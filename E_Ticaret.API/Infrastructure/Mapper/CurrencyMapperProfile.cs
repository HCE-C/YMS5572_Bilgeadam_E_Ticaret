using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.Currency;
using E_Ticaret.Model.Entities;

namespace E_Ticaret.API.Infrastructure.Mapper
{
    public class CurrencyMapperProfile : Profile
    {
        public CurrencyMapperProfile()
        {
            CreateMap<Currency, CurrencyRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Currency, CurrencyResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}