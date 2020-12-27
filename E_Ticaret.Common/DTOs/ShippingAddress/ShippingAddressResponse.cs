using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Common.DTOs.Country;
using E_Ticaret.Common.DTOs.Location;
using E_Ticaret.Common.DTOs.Order;

namespace E_Ticaret.Common.DTOs.ShippingAddress
{
    public class ShippingAddressResponse : BaseDto
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int CountryId { get; set; }
        public int LocationId { get; set; }
        public string SubLocation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
    }
}
