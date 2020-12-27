using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.GeneralEnums;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Sipariş Kalemia
    public class OrderItem : CoreEntity
    {
        public OrderItem()
        {
            OrderItemCustomizations = new HashSet<OrderItemCustomization>();
        }
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
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int OrderItemSubscriptionId { get; set; }
        public OrderItemSubscription OrderItemSubscription { get; set; }

        public ICollection<OrderItemCustomization> OrderItemCustomizations { get; set; }
        
        public Member CreatedMemberOrderItem { get; set; }
        public Member ModifiedMemberOrderItem { get; set; }
    }
}