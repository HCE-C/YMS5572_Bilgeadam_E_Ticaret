using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.ShippingAddress;
using E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM;

namespace E_Ticaret.WEBUI.Infrastructure.Mapper
{
    public class ShippingAddressMapperProfile : Profile
    {
        public ShippingAddressMapperProfile()
        {
            CreateMap<CreateShippingViewModel, ShippingAddressRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateShippingViewModel, ShippingAddressResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateShippingViewModel, ShippingAddressRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateShippingViewModel, ShippingAddressResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}