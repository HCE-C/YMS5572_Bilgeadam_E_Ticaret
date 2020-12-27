using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class MemberMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasExtended();

                entity.Property(m => m.Firstname).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Surname).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Email).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Password).HasMaxLength(10).IsRequired();
                entity.Property(m => m.Title).HasMaxLength(10).IsRequired();
                entity.Property(m => m.PhoneNumber).HasMaxLength(255);
                entity.Property(m => m.MobilePhoneNumber).HasMaxLength(255);
                entity.Property(m => m.OtherLocation).HasMaxLength(255);
                entity.Property(m => m.Address).HasMaxLength(65535);
                entity.Property(m => m.TaxNumber).HasMaxLength(255);
                entity.Property(m => m.TcId).HasMaxLength(11);
                entity.Property(m => m.MemberStatus).IsRequired();
                entity.Property(m => m.Role).HasMaxLength(10);

                entity.Property(m => m.ZipCode).HasMaxLength(50);
                entity.Property(m => m.CommercialName).HasMaxLength(255);
                entity.Property(m => m.TaxOffice).HasMaxLength(255);
                entity.Property(m => m.LastIp).HasMaxLength(255);
                entity.Property(m => m.District).HasMaxLength(255);
                entity.Property(m => m.DeviceType).HasMaxLength(255).IsRequired();
                entity.Property(m => m.DeviceInfo).HasMaxLength(65535);

                entity
                    .HasOne(m => m.Country)
                    .WithMany(c => c.Members)
                    .HasForeignKey(m => m.CountryId);

                entity
                    .HasOne(m => m.Location)
                    .WithMany(l => l.Members)
                    .HasForeignKey(m => m.LocationId);

                entity
                    .HasOne(m => m.MemberGroup)
                    .WithMany(mg => mg.Members)
                    .HasForeignKey(m => m.MemberGroupId);

                entity
                    .HasOne(m => m.ReferredMember)
                    .WithMany(m => m.ReferredMembers)
                    .HasForeignKey(m => m.ReferredMemberId);

                entity
                    .HasOne(m => m.CreatedMember)
                    .WithMany(m => m.CreatedMembers)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMember)
                    .WithMany(m => m.ModifiedMembers)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }
    }
}
