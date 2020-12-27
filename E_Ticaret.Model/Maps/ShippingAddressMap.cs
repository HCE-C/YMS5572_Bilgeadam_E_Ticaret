using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.Maps
{
    public class ShippingAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingAddress>(entity =>
            {
                entity.HasExtended();

                entity.Property(m => m.Firstname).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Surname).HasMaxLength(255).IsRequired();
                entity.Property(m => m.CountryId).IsRequired();
                entity.Property(m => m.LocationId).IsRequired();
                entity.Property(m => m.SubLocation).HasMaxLength(128);
                entity.Property(m => m.Address).HasMaxLength(65535).IsRequired();
                entity.Property(m => m.PhoneNumber).HasMaxLength(32);
                entity.Property(m => m.MobilePhoneNumber).HasMaxLength(32).IsRequired();

                entity
                    .HasMany(s => s.Orders)
                    .WithOne(o => o.ShippingAddress)
                    .HasForeignKey(s => s.ShippingAddressId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(b => b.Country)
                    .WithMany(o => o.ShippingAddresses)
                    .HasForeignKey(b => b.CountryId);

                entity
                    .HasOne(b => b.Location)
                    .WithMany(o => o.ShippingAddresses)
                    .HasForeignKey(b => b.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                   .HasOne(m => m.CreatedMemberShippingAddress)
                   .WithMany(m => m.CreatedMemberShippingAddresses)
                   .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberShippingAddress)
                    .WithMany(m => m.ModifiedMemberShippingAddresses)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }

}
