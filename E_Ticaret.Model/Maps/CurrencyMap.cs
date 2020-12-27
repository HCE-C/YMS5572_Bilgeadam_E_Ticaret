using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class CurrencyMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasExtended();

                entity.Property(c => c.Label).HasMaxLength(50);
                entity.Property(c => c.Abbr).HasMaxLength(5);

                entity
                   .HasOne(c => c.CreatedMemberCurrency)
                   .WithMany(m => m.CreatedMemberCurrencies)
                   .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.ModifiedMemberCurrency)
                    .WithMany(m => m.ModifiedMemberCurrencies)
                    .HasForeignKey(c => c.ModifiedMemberId);
            });
        }
    }
}
