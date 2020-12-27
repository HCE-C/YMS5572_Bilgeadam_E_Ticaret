using E_Ticaret.Model.Enums.GeneralEnums;

namespace E_Ticaret.WEBUI.Models.AdressViewModels.BillingAdressVM
{
    public class CreateBillingAdressVM
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public int LocationId { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string IdentityRegistrationNumber { get; set; }
    }
}
