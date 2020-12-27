using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class CountryMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasExtended();

                entity.Property(c => c.Name).HasMaxLength(255).IsRequired();

                entity
                   .HasOne(c => c.CreatedMemberCountry)
                   .WithMany(m => m.CreatedMemberCountries)
                   .HasForeignKey(c => c.CreatedMemberId);

                entity
                    .HasOne(c => c.ModifiedMemberCountry)
                    .WithMany(m => m.ModifiedMemberCountries)
                    .HasForeignKey(c => c.ModifiedMemberId);
            });
        }
    }
}
