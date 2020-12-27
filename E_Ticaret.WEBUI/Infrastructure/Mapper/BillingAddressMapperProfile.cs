using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.BillingAddress;
using E_Ticaret.WEBUI.Models.AdressViewModels.BillingAdressVM;

namespace E_Ticaret.WEBUI.Infrastructure.Mapper
{
    public class BillingAddressMapperProfile : Profile
    {
        public BillingAddressMapperProfile()
        {
            CreateMap<CreateBillingAdressVM, BillingAddressRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateBillingAdressVM, BillingAddressResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateBillingAdressVM, BillingAddressRequest>()
               .ReverseMap()
               .IgnoreAllNonExisting()
               .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UpdateBillingAdressVM, BillingAddressResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}