using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class ProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasExtended();

                entity.Property(p => p.Name).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Slug).HasMaxLength(65535);
                entity.Property(p => p.FullName).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Sku).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Barcode).HasMaxLength(255);
                entity.Property(p => p.Price1).IsRequired();
                entity.Property(p => p.Distributor).HasMaxLength(255);
                entity.Property(p => p.Gift).HasMaxLength(255);
                entity.Property(p => p.MarketPriceDetail).HasMaxLength(255);
                entity.Property(p => p.MetaKeyword).HasMaxLength(65535);
                entity.Property(p => p.MetaDescription).HasMaxLength(65535);
                entity.Property(p => p.PageTitle).HasMaxLength(255);
                entity.Property(p => p.ShortDetails).HasMaxLength(255);
                entity.Property(p => p.SearchKeyWords).HasMaxLength(255);
                entity.Property(p => p.InstallmentTreshold).HasMaxLength(10);
                entity.Property(p => p.CurrencyId).IsRequired();

                entity
                    .HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(p => p.Currency)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CurrencyId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(p => p.Parent)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.ParentId);

                entity
                    .HasOne(m => m.CreatedMemberProduct)
                    .WithMany(m => m.CreatedMemberProducts)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberProduct)
                    .WithMany(m => m.ModifiedMemberProducts)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }
    }
}
