using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.Category;
using E_Ticaret.Model.Entities;

namespace E_Ticaret.API.Infrastructure.Mapper
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryRequest>()
              .ReverseMap()
              .IgnoreAllNonExisting()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
