using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class PimageMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pimage>(entity =>
            {
                entity.HasExtended();

                entity.Property(p => p.Filename).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Extension).IsRequired();
                entity.Property(p => p.DirectoryName).HasMaxLength(10);
                entity.Property(p => p.Revision).HasMaxLength(30);
                entity.Property(p => p.SortOrder).IsRequired();

                entity
                    .HasOne(pi => pi.Product)
                    .WithMany(p => p.Pimages)
                    .HasForeignKey(pi => pi.ProductId);

                entity
                    .HasOne(m => m.CreatedMemberPimage)
                    .WithMany(m => m.CreatedMemberPimages)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberPimage)
                    .WithMany(m => m.ModifiedMemberPimages)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }

    }
}
