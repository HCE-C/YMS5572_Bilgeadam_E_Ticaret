using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM
{
    public class CreateShippingViewModel
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
