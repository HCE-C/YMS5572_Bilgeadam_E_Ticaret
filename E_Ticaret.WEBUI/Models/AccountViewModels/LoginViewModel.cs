using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WEBUI.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="E-Posta Bilgisi Zorunludur.")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir e-posta giriniiz")]
        [MaxLength(255,ErrorMessage ="Maksimum 255 karakter giriebilirsiniz.")]
        [DisplayName("E-posta")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Şifre alanı zorunludur")]
        [StringLength(10, MinimumLength =6,ErrorMessage ="Lütfen 6 ile 10 karakter arası bir şifre giriniz")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        public bool IsPersist { get; set; }
    }
}
