using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.GeneralEnums;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Şehir
    public class Location : CoreEntity
    {
        public Location()
        {
            Members = new HashSet<Member>();
            BillingAddresses = new HashSet<BillingAddress>();
            ShippingAddresses = new HashSet<ShippingAddress>();
        }
        public string Name { get; set; }
        public Predefined Predefined { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<BillingAddress> BillingAddresses { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

        public Member CreatedMemberLocation { get; set; }
        public Member ModifiedMemberLocation { get; set; }
    }
}