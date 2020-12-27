using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.MailList;
using E_Ticaret.Model.Entities;

namespace E_Ticaret.API.Infrastructure.Mapper
{
    public class MailListMapperProfile : Profile
    {
        public MailListMapperProfile()
        {
            CreateMap<MailList, MailListRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MailList, MailListResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
