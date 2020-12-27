using E_Ticaret.WEBUI.Models.AdressViewModels.BillingAdressVM;
using E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM;

namespace E_Ticaret.WEBUI.Models.AdressViewModels
{
    public class UpdateAddressVM
    {
        public UpdateBillingAdressVM UpdateBillingAdressVM { get; set; }
        public UpdateShippingViewModel UpdateShippingViewModel { get; set; }

    }
}
