using E_Ticaret.Core.Entity;
using E_Ticaret.Model.Enums.GeneralEnums;
using System.Collections.Generic;

namespace E_Ticaret.Model.Entities
{
    //Kur
    public class Currency : CoreEntity
    {
        public Currency()
        {
            Products = new HashSet<Product>();
            Orders = new HashSet<Order>();
            Currencies = new HashSet<Currency>();
        }
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; }
        public IsPrimary IsPrimary { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Currency> Currencies { get; set; }

        public Member CreatedMemberCurrency { get; set; }
        public Member ModifiedMemberCurrency { get; set; }
    }
}