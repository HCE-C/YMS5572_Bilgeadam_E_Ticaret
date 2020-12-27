using E_Ticaret.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.ShippingAddress
{
    public class ShippingAddressRequest : BaseDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public int LocationId { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public int OrderId { get; set; }
    }
}
