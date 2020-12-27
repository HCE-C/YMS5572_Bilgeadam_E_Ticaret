using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class RegionMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasExtended();

                entity.Property(r => r.Name).HasMaxLength(255).IsRequired();

                entity
                    .HasOne(m => m.CreatedMemberRegion)
                    .WithMany(m => m.CreatedMemberRegions)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberRegion)
                    .WithMany(m => m.ModifiedMemberRegions)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }
    }
}
