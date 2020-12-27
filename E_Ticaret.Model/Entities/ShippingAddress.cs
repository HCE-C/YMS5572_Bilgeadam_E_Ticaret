using E_Ticaret.Core.Entity;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Sipariş Adresi
    public class ShippingAddress : CoreEntity
    {
        public ShippingAddress()
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

        public ICollection<Order> Orders { get; set; }

        public Member CreatedMemberShippingAddress { get; set; }
        public Member ModifiedMemberShippingAddress { get; set; }
    }
}