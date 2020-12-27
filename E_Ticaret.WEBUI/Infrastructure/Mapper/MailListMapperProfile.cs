using AutoMapper;
using E_Ticaret.Common.Client.Extensions;
using E_Ticaret.Common.DTOs.MailList;
using E_Ticaret.Common.DTOs.MailListGroup;
using E_Ticaret.WEBUI.Areas.Admin.Models.MailListViewModels;

namespace E_Ticaret.WEBUI.Infrastructure.Mapper
{
    public class MailListMapperProfile : Profile
    {
        public MailListMapperProfile()
        {
            CreateMap<MailListVM, MailListRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MailListVM, MailListResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MailListGroupVM, MailListGroupRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MailListGroupVM, MailListGroupResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}