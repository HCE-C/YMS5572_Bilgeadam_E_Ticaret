using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model.Enums.GeneralEnums;

namespace E_Ticaret.Common.DTOs.BillingAddress
{
    public class BillingAddressRequest : BaseDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string CountryId { get; set; }
        public string LocationId { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public int OrderId { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string IdentityRegistrationNumber { get; set; }
    }
}
