using E_Ticaret.Core.Entity;
using E_Ticaret.Core.MyAnnotation;
using E_Ticaret.Model.Enums.GeneralEnums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Model.Entities
{
    //Fatura Adresi
    public class BillingAddress : CoreEntity
    {
        public BillingAddress()
        {
            Orders = new HashSet<Order>();
        }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }
        public string IdentityRegistrationNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Member CreatedMemberBillingAddress { get; set; }
        public Member ModifiedMemberBillingAddress { get; set; }
    }
}