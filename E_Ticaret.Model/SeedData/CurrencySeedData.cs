using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class CurrencySeedData : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(
                new Currency()
                {
                    Id = 2,
                    Status = Core.Entity.Enums.Status.Active,
                    Label = "Türk Lirası",
                    BuyingPrice = 1,
                    SellingPrice = 1,
                    Abbr = "TL",
                    IsPrimary = Enums.GeneralEnums.IsPrimary.Yes
                },
                new Currency()
                {
                    Id = 3,
                    Status = Core.Entity.Enums.Status.Active,
                    Label = "Dolar",
                    BuyingPrice = 10,
                    SellingPrice = 9,
                    Abbr = "USD",
                    IsPrimary = Enums.GeneralEnums.IsPrimary.No
                });
        }

    }
}
