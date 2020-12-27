using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class MailListMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailList>(entity =>
            {
                entity.HasExtended();

                entity.Property(m => m.Name).HasMaxLength(255).IsRequired();
                entity.Property(m => m.Email).HasMaxLength(255).IsRequired();

                entity
                    .HasOne(m => m.MailListGroup)
                    .WithMany(mg => mg.MailLists)
                    .HasForeignKey(m => m.MailListGroupId);

                entity
                    .HasOne(m => m.CreatedMemberMailList)
                    .WithMany(m => m.CreatedMemberMailLists)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberMailList)
                    .WithMany(m => m.ModifiedMemberMailLists)
                    .HasForeignKey(m => m.ModifiedMemberId);

            });
        }
    }
}
