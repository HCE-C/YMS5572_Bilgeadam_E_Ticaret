using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.MailListGroup;
using E_Ticaret.Model.Entities;

namespace E_Ticaret.API.Infrastructure.Mapper
{
    public class MailListGroupMapperProfile : Profile
    {
        public MailListGroupMapperProfile()
        {
            CreateMap<MailListGroup, MailListGroupRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MailListGroup, MailListGroupResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
