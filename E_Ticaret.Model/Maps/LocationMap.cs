using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class LocationMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasExtended();

                entity.Property(l => l.Name).HasMaxLength(255).IsRequired();

                entity
                    .HasOne(l => l.Country)
                    .WithMany(c => c.Locations)
                    .HasForeignKey(l => l.CountryId);

                entity
                    .HasOne(l => l.Region)
                    .WithMany(r => r.Locations)
                    .HasForeignKey(l => l.RegionId);

                entity
                    .HasOne(l => l.CreatedMemberLocation)
                    .WithMany(m => m.CreatedMemberLocations)
                    .HasForeignKey(l => l.CreatedMemberId);

                entity
                    .HasOne(l => l.ModifiedMemberLocation)
                    .WithMany(m => m.ModifiedMemberLocations)
                    .HasForeignKey(l => l.ModifiedMemberId);
            });
        }
    }
}
