using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class BillingAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillingAddress>(entity =>
            {
                entity.HasExtended();

                entity.Property(m => m.Firstname).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Surname).HasMaxLength(255).IsRequired();
                entity.Property(m => m.CountryId).IsRequired();
                entity.Property(m => m.LocationId).IsRequired();
                entity.Property(m => m.Address).HasMaxLength(65535).IsRequired();
                entity.Property(m => m.PhoneNumber).HasMaxLength(32);
                entity.Property(m => m.MobilePhoneNumber).HasMaxLength(32).IsRequired();
                entity.Property(m => m.TaxNo).HasMaxLength(64);
                entity.Property(m => m.TaxOffice).HasMaxLength(255);
                entity.Property(m => m.IdentityRegistrationNumber).HasMaxLength(32);

                entity
                .HasMany(x => x.Orders)
                .WithOne(x => x.BillingAddress)
                .HasForeignKey(x => x.BillingAddressId)
                .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(b => b.Country)
                    .WithMany(o => o.BillingAddresses)
                    .HasForeignKey(b => b.CountryId);

                entity
                    .HasOne(b => b.Location)
                    .WithMany(o => o.BillingAddresses)
                    .HasForeignKey(b => b.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(b => b.CreatedMemberBillingAddress)
                    .WithMany(m => m.CreatedMemberBillingAddresses)
                    .HasForeignKey(b => b.CreatedMemberId);

                entity
                    .HasOne(b => b.ModifiedMemberBillingAddress)
                    .WithMany(m => m.ModifiedMemberBillingAddresses)
                    .HasForeignKey(b => b.ModifiedMemberId);
            });
        }
    }
}
