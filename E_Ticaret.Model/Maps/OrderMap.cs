using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class OrderMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasExtended();

                entity.Property(o => o.CustomerFirstname).HasMaxLength(255).IsRequired();
                entity.Property(o => o.CustomerSurname).HasMaxLength(255).IsRequired();
                entity.Property(o => o.CustomerEmail).HasMaxLength(255).IsRequired();
                entity.Property(o => o.CustomerPhone).HasMaxLength(32);
                entity.Property(o => o.PaymentTypeName).HasMaxLength(128).IsRequired();
                entity.Property(o => o.PaymentProviderCode).HasMaxLength(128).IsRequired();
                entity.Property(o => o.PaymentProviderName).HasMaxLength(128).IsRequired();
                entity.Property(o => o.PaymentGatewayCode).HasMaxLength(128).IsRequired();
                entity.Property(o => o.PaymentGatewayName).HasMaxLength(128).IsRequired();
                entity.Property(o => o.BankName).HasMaxLength(128);
                entity.Property(o => o.ClientIp).HasMaxLength(64).IsRequired();
                entity.Property(o => o.UserAgent).HasMaxLength(1024);
                entity.Property(o => o.UserAgent).HasMaxLength(255).IsRequired();
                entity.Property(o => o.CurrencyId).IsRequired();
                entity.Property(o => o.Amount).IsRequired();
                entity.Property(o => o.CouponDiscount).IsRequired();
                entity.Property(o => o.TaxAmount).IsRequired();
                entity.Property(o => o.PromotionDiscount).IsRequired();
                entity.Property(o => o.GeneralAmount).IsRequired();
                entity.Property(o => o.ShippingAmount).IsRequired();
                entity.Property(o => o.AdditionalServiceAmount).IsRequired();
                entity.Property(o => o.FinalAmount).IsRequired();
                entity.Property(o => o.TransactionId).HasMaxLength(255);
                entity.Property(o => o.OrderStatus).IsRequired();
                entity.Property(o => o.PaymentStatus).IsRequired();
                entity.Property(o => o.ErrorMessage).HasMaxLength(65535);
                entity.Property(o => o.DeviceType).IsRequired();
                entity.Property(o => o.Referrer).HasMaxLength(65535);
                entity.Property(o => o.GiftNote).HasMaxLength(65535);
                entity.Property(o => o.MemberGroupName).HasMaxLength(255);
                entity.Property(o => o.ShippingProviderCode).HasMaxLength(128);
                entity.Property(o => o.ShippingProviderName).HasMaxLength(128);
                entity.Property(o => o.ShippingCompanyName).HasMaxLength(128);
                entity.Property(o => o.ShippingTrackingCode).HasMaxLength(255);
                entity.Property(o => o.Source).HasMaxLength(255).IsRequired();

                entity
                    .HasOne(o => o.Currency)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CurrencyId);

                entity
                    .HasOne(o => o.MailList)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.MailListId);

                entity
                    .HasOne(o => o.Member)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.MemberId);

                entity
                    .HasOne(m => m.CreatedMemberOrder)
                    .WithMany(m => m.CreatedMemberOrders)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberOrder)
                    .WithMany(m => m.ModifiedMemberOrders)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }
    }
}
