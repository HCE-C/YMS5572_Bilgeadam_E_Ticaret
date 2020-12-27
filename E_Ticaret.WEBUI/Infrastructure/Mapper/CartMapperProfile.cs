using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.Cart;
using E_Ticaret.WEBUI.Models.CartViewModels;

namespace E_Ticaret.WEBUI.Infrastructure.Mapper
{
    public class CartMapperProfile : Profile
    {
        public CartMapperProfile()
        {
            CreateMap<CartViewModel, CartRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CartViewModel, CartResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}