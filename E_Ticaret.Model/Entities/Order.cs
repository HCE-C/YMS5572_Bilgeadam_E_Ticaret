using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.OrderEnums;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Sipariş
    public class Order : CoreEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderItems = new HashSet<OrderItem>();
        }
        public string CustomerFirstname { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string PaymentTypeName { get; set; }
        public string PaymentProviderCode { get; set; }
        public string PaymentProviderName { get; set; }
        public string PaymentGatewayCode { get; set; }
        public string PaymentGatewayName { get; set; }
        public string BankName { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string CurrencyRates { get; set; }
        public decimal Amount { get; set; }
        public decimal CouponDiscount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal PromotionDiscount { get; set; }
        public decimal GeneralAmount { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal AdditionalServiceAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal SumOfGainedPoints { get; set; }
        public int Installment { get; set; }
        public decimal InstallmentRate { get; set; }
        public int ExtraInstallment { get; set; }
        public string TransactionId { get; set; }
        public HasUserNote HasUserNote { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string ErrorMessage { get; set; }
        public DeviceType DeviceType { get; set; }
        public string Referrer { get; set; }
        public string InvoicePrintCount { get; set; }
        public UseGiftPackage UseGiftPackage { get; set; }
        public string GiftNote { get; set; }
        public string MemberGroupName { get; set; }
        public UsePromotion UsePromotion { get; set; }
        public string ShippingProviderCode { get; set; }
        public string ShippingProviderName { get; set; }
        public string ShippingCompanyName { get; set; }
        public ShippingPaymentType ShippingPaymentType { get; set; }
        public string ShippingTrackingCode { get; set; }
        public string Source { get; set; }


        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int MailListId { get; set; }
        public MailList MailList { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public BillingAddress BillingAddress { get; set; }

        public Member CreatedMemberOrder { get; set; }
        public Member ModifiedMemberOrder { get; set; }

    }
}
