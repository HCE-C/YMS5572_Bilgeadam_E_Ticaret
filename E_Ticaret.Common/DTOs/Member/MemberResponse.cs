using E_Ticaret.Common.Client.Models;
using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.Country;
using E_Ticaret.Common.DTOs.Location;
using E_Ticaret.Common.DTOs.MemberGroup;
using E_Ticaret.Model;

namespace E_Ticaret.Common.DTOs.Member
{
    public class MemberResponse : BaseDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public string Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public int CountryId { get; set; }
        public CountryResponse Country { get; set; }
        public int LocationId { get; set; }
        public LocationResponse Location { get; set; }
        public int MemberGroupId { get; set; }
        public MemberGroupResponse MemberGroup{ get; set; }
        public int ReferredMemberId { get; set; }
        public GetAccessToken AccessToken { get; set; }
    }
}
