using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.GeneralEnums;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Üye
    public class Member : CoreEntity
    {
        public Member()
        {
            Orders = new HashSet<Order>();
            ReferredMembers = new HashSet<Member>();

            CreatedMembers = new HashSet<Member>();
            ModifiedMembers = new HashSet<Member>();
            CreatedMemberBillingAddresses = new HashSet<BillingAddress>();
            ModifiedMemberBillingAddresses = new HashSet<BillingAddress>();
            CreatedMemberShippingAddresses = new HashSet<ShippingAddress>();
            ModifiedMemberShippingAddresses = new HashSet<ShippingAddress>();
            CreatedMemberBrands = new HashSet<Brand>();
            ModifiedMemberBrands = new HashSet<Brand>();
            CreatedMemberCarts = new HashSet<Cart>();
            ModifiedMemberCarts = new HashSet<Cart>();
            CreatedMemberCartItems = new HashSet<CartItem>();
            ModifiedMemberCartItems = new HashSet<CartItem>();
            CreatedMemberCartItemAttributes = new HashSet<CartItemAttribute>();
            ModifiedMemberCartItemAttributes = new HashSet<CartItemAttribute>();
            CreatedMemberProductToCountDowns = new HashSet<ProductToCountDown>();
            ModifiedMemberProductToCountDowns = new HashSet<ProductToCountDown>();
            ModifiedMemberCountries = new HashSet<Country>();
            CreatedMemberCountries = new HashSet<Country>();
            CreatedMemberCurrencies = new HashSet<Currency>();
            ModifiedMemberCurrencies = new HashSet<Currency>();
            CreatedMemberLocations = new HashSet<Location>();
            ModifiedMemberLocations = new HashSet<Location>();
            CreatedMemberMailLists = new HashSet<MailList>();
            ModifiedMemberMailLists = new HashSet<MailList>();
            CreatedMemberMailListGroups = new HashSet<MailListGroup>();
            ModifiedMemberMailListGroups = new HashSet<MailListGroup>();
            CreatedMemberGroups = new HashSet<MemberGroup>();
            ModifiedMemberGroups = new HashSet<MemberGroup>();
            CreatedMemberOrders = new HashSet<Order>();
            ModifiedMemberOrders = new HashSet<Order>();
            CreatedMemberOrderDetails = new HashSet<OrderDetail>();
            ModifiedMemberOrderDetails = new HashSet<OrderDetail>();
            CreatedMemberOrderItems = new HashSet<OrderItem>();
            ModifiedMemberOrderItems = new HashSet<OrderItem>();
            CreatedMemberOrderItemCustomizations = new HashSet<OrderItemCustomization>();
            ModifiedMemberOrderItemCustomizations = new HashSet<OrderItemCustomization>();
            CreatedMemberOrderItemSubscriptions = new HashSet<OrderItemSubscription>();
            ModifiedMemberOrderItemSubscriptions = new HashSet<OrderItemSubscription>();
            CreatedMemberPimages = new HashSet<Pimage>();
            ModifiedMemberPimages = new HashSet<Pimage>();
            CreatedMemberPrices = new HashSet<Price>();
            ModifiedMemberPrices = new HashSet<Price>();
            ModifiedMemberCategories = new HashSet<Category>();
            CreatedMemberCategories = new HashSet<Category>();
            CreatedMemberProducts = new HashSet<Product>();
            ModifiedMemberProducts = new HashSet<Product>();
            CreatedMemberProductToCategories = new HashSet<ProductToCategory>();
            ModifiedMemberProductToCategories = new HashSet<ProductToCategory>();
            CreatedMemberPromotions = new HashSet<Promotion>();
            ModifiedMemberPromotions = new HashSet<Promotion>();
            CreatedMemberRegions = new HashSet<Region>();
            ModifiedMemberRegions = new HashSet<Region>();
            CreatedMemberShopTokens = new HashSet<ShopToken>();
            ModifiedMemberShopTokens = new HashSet<ShopToken>();
            
        }

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public string Birthdate { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string OtherLocation { get; set; }
        public string Address { get; set; }
        public string TaxNumber { get; set; }
        public string TcId { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public string LastLoginDate { get; set; }
        public string ZipCode { get; set; }
        public string CommercialName { get; set; }
        public string TaxOffice { get; set; }
        public string LastMailSentDate { get; set; }
        public string LastIp { get; set; }
        public decimal GainedPointAmount { get; set; }
        public decimal SpentPonitAmount { get; set; }
        public AllowedToCampaigns AllowedToCampaigns { get; set; }
        public decimal ReferredMemberGainedPointAmount { get; set; }
        public string District { get; set; }
        public string DeviceType { get; set; }
        public string DeviceInfo { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public int? MemberGroupId { get; set; }
        public MemberGroup MemberGroup { get; set; }
        public int? ReferredMemberId { get; set; }
        public Member ReferredMember { get; set; }
        public ICollection<Member> ReferredMembers { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Member CreatedMember { get; set; }
        public Member ModifiedMember { get; set; }
        public ICollection<Member> CreatedMembers { get; set; }
        public ICollection<Member> ModifiedMembers { get; set; }
        public ICollection<BillingAddress> CreatedMemberBillingAddresses { get; set; }
        public ICollection<BillingAddress> ModifiedMemberBillingAddresses { get; set; }
        public ICollection<ShippingAddress> CreatedMemberShippingAddresses { get; set; }
        public ICollection<ShippingAddress> ModifiedMemberShippingAddresses { get; set; }
        public ICollection<Brand> CreatedMemberBrands { get; set; }
        public ICollection<Brand> ModifiedMemberBrands { get; set; }
        public ICollection<Cart> CreatedMemberCarts { get; set; }
        public ICollection<Cart> ModifiedMemberCarts { get; set; }
        public ICollection<CartItem> CreatedMemberCartItems { get; set; }
        public ICollection<CartItem> ModifiedMemberCartItems { get; set; }
        public ICollection<CartItemAttribute> CreatedMemberCartItemAttributes { get; set; }
        public ICollection<CartItemAttribute> ModifiedMemberCartItemAttributes { get; set; }
        public ICollection<ProductToCountDown> CreatedMemberProductToCountDowns { get; set; }
        public ICollection<ProductToCountDown> ModifiedMemberProductToCountDowns { get; set; }
        public ICollection<Country> ModifiedMemberCountries { get; set; }
        public ICollection<Country> CreatedMemberCountries { get; set; }
        public ICollection<Currency> CreatedMemberCurrencies { get; set; }
        public ICollection<Currency> ModifiedMemberCurrencies { get; set; }
        public ICollection<Location> CreatedMemberLocations { get; set; }
        public ICollection<Location> ModifiedMemberLocations { get; set; }
        public ICollection<MailList> CreatedMemberMailLists { get; set; }
        public ICollection<MailList> ModifiedMemberMailLists { get; set; }
        public ICollection<MailListGroup> CreatedMemberMailListGroups { get; set; }
        public ICollection<MailListGroup> ModifiedMemberMailListGroups { get; set; }
        public ICollection<MemberGroup> CreatedMemberGroups { get; set; }
        public ICollection<MemberGroup> ModifiedMemberGroups { get; set; }
        public ICollection<Order> CreatedMemberOrders { get; set; }
        public ICollection<Order> ModifiedMemberOrders { get; set; }
        public ICollection<OrderDetail> CreatedMemberOrderDetails { get; set; }
        public ICollection<OrderDetail> ModifiedMemberOrderDetails { get; set; }
        public ICollection<OrderItem> CreatedMemberOrderItems { get; set; }
        public ICollection<OrderItem> ModifiedMemberOrderItems { get; set; }
        public ICollection<OrderItemCustomization> CreatedMemberOrderItemCustomizations { get; set; }
        public ICollection<OrderItemCustomization> ModifiedMemberOrderItemCustomizations { get; set; }
        public ICollection<OrderItemSubscription> CreatedMemberOrderItemSubscriptions { get; set; }
        public ICollection<OrderItemSubscription> ModifiedMemberOrderItemSubscriptions { get; set; }
        public ICollection<Pimage> CreatedMemberPimages { get; set; }
        public ICollection<Pimage> ModifiedMemberPimages { get; set; }
        public ICollection<Price> CreatedMemberPrices { get; set; }
        public ICollection<Price> ModifiedMemberPrices { get; set; }
        public ICollection<Category> ModifiedMemberCategories { get; set; }
        public ICollection<Category> CreatedMemberCategories { get; set; }
        public ICollection<ProductToCategory> CreatedMemberProductToCategories { get; set; }
        public ICollection<ProductToCategory> ModifiedMemberProductToCategories { get; set; }
        public ICollection<Promotion> CreatedMemberPromotions { get; set; }
        public ICollection<Promotion> ModifiedMemberPromotions { get; set; }
        public ICollection<Region> CreatedMemberRegions { get; set; }
        public ICollection<Region> ModifiedMemberRegions { get; set; }
        public ICollection<ShopToken> CreatedMemberShopTokens { get; set; }
        public ICollection<ShopToken> ModifiedMemberShopTokens { get; set; }
        public ICollection<Product> CreatedMemberProducts { get; set; }
        public ICollection<Product> ModifiedMemberProducts { get; set; }
    }
}