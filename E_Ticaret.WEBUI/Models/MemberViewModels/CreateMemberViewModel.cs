using E_Ticaret.Common.Client.Enums;
using E_Ticaret.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WEBUI.Models.MemberViewModels
{
    public class CreateMemberViewModel
    {
        [Required]
        [StringLength(255,MinimumLength =3)]
        [DisplayName("Ad")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-Posta Bilgisi Zorunludur.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta giriniiz")]
        [MaxLength(255, ErrorMessage = "Maksimum 255 karakter giriebilirsiniz.")]
        [DisplayName("E-posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Lütfen 6 ile 10 karakter arası bir şifre giriniz")]
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
        [DisplayName("Ülke")]
        public int CountryId { get; set; }
        [DisplayName("Şehir")]
        public int LocationId { get; set; }
        [DisplayName("Referans Olan Üyenin Mail Adresi")]
        public int ReferredMemberId { get; set; }
        public Status Status { get; set; }
    }
}
