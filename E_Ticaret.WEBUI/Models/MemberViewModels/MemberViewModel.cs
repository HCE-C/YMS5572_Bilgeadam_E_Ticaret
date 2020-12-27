using E_Ticaret.Common.Client.Enums;
using E_Ticaret.Model;
using System.ComponentModel;

namespace E_Ticaret.WEBUI.Models.MemberViewModels
{
    public class MemberViewModel
    {
        [DisplayName("Ad")]
        public string Firstname { get; set; }
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [DisplayName("E-posta")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        public string Title { get; set; }
        [DisplayName("Cinsiyet")]
        public Gender Gender { get; set; }
        [DisplayName("Doğum Tarihi")]
        public string Birthdate { get; set; }
        [DisplayName("Telefon No")]
        public string PhoneNumber { get; set; }
        [DisplayName("Cep Telefon No")]
        public string MobilePhoneNumber { get; set; }
        public int CountryId { get; set; }
        public int LocationId { get; set; }
        public int ReferredMemberId { get; set; }
        public Status Status { get; set; }
    }
}
