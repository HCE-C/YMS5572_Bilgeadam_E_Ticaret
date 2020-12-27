using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Ülke
    public class Country : CoreEntity
    {
        public Country()
        {
            Members = new HashSet<Member>();
            Locations = new HashSet<Location>();
            BillingAddresses = new HashSet<BillingAddress>();
            ShippingAddresses = new HashSet<ShippingAddress>();
            
        }
        public string Name { get; set; }

        public ICollection<Member> Members { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<BillingAddress> BillingAddresses { get; set; }
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }

        public Member ModifiedMemberCountry { get; set; }
        public Member CreatedMemberCountry { get; set; }

    }
}