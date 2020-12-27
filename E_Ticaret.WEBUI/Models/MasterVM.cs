using E_Ticaret.WEBUI.Models.AdressViewModels.ShippingAdressVM;

namespace E_Ticaret.WEBUI.Models
{
    public class MasterVM
    {
        public int CartItemId { get; set; }
        public decimal Quantity { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string FilePath { get; set; }
        public string SessionId { get; set; }
        public int Locked { get; set; }
        public int PromotionId { get; set; }
        public int MemberId { get; set; }
        public int ShopTokenId { get; set; }
        public UpdateShippingViewModel UpdateShippingViewModel { get; set; }
    }
}
