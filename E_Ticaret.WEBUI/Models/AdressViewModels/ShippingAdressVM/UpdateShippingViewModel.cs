using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM
{
    public class UpdateShippingViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Ad")]
        [Required]
        public string Firstname { get; set; }
        [Display(Name = "Soyad")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Ülke")]
        [Required]
        public int CountryId { get; set; }
        [Display(Name = "Şehir")]
        [Required]
        public int LocationId { get; set; }
        [Display(Name = "İlçe")]
        [Required]
        public string SubLocation { get; set; }
        [Display(Name = "Adres")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Sabit Telefon")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Cep Telefon")]
        [Required]
        public string MobilePhoneNumber { get; set; }
    }
}
