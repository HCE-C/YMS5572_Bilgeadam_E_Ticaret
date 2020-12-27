using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.Member
{
   public class MemberRequest : BaseDto
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
        public int LocationId { get; set; }
        public int MemberGroupId { get; set; }
        public int ReferredMemberId { get; set; }
        public string DeviceType { get; set; }
        public MemberStatus MemberStatus { get; set; }       
    }
}
