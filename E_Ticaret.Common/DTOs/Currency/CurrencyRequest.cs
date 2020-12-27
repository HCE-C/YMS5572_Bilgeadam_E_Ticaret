using E_Ticaret.Common.DTOs.Base;
using E_Ticaret.Model.Enums.GeneralEnums;

namespace E_Ticaret.Common.DTOs.Currency
{
    public class CurrencyRequest : BaseDto
    {
        public string Label { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Abbr { get; set; }
        public IsPrimary IsPrimary { get; set; }
    }
}
