using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model;
using E_Ticaret.Model.Enums.GeneralEnums;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Common.DTOs.OrderItem
{
    public class OrderItemRequest : BaseDto
    {
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ProductBarcode { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }
        public int ProductTax { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal ProductMoneyOrderDiscount { get; set; }
        public decimal ProductWeight { get; set; }
        public ProductStockTypeLabel ProductStockTypeLabel { get; set; }
        public IsProductPromotioned IsProductPromotioned { get; set; }
        public decimal Discount { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CurrencyId { get; set; }
        public int OrderItemSubscriptionId { get; set; }
    }
}
