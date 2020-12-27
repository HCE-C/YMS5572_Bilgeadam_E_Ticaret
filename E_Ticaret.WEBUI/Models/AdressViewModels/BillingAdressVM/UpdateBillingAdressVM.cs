using E_Ticaret.Model.Enums.GeneralEnums;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.WEBUI.Models.AdressViewModels.BillingAdressVM
{
    public class UpdateBillingAdressVM
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
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
        [Display(Name = "Fatura Tipi")]
        [Required]
        public InvoiceType InvoiceType { get; set; }
        [Display(Name = "Vergi Kimlik No")]
        public string TaxNo { get; set; }
        [Display(Name = "Vergi Dairesi")]
        public string TaxOffice { get; set; }
        [Display(Name = "Tc Kimlik No")]
        public string IdentityRegistrationNumber { get; set; }
    }
}
