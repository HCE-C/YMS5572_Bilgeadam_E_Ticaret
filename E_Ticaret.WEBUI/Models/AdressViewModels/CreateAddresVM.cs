using E_Ticaret.WEBUI.Models.AdressViewModels.BillingAdressVM;
using E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM;

namespace E_Ticaret.WEBUI.Models.AdressViewModels
{
    public class CreateAddresVM
    {
        public CreateBillingAdressVM CreateBillingAdressVM { get; set; }
        public CreateShippingViewModel CreateShippingViewModel { get; set; }
    }
}
