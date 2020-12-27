using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Model.Maps
{
    public class MailListGroupMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MailListGroup>(entity =>
            {
                entity.HasExtended();

                entity.Property(mg => mg.Name).HasMaxLength(255).IsRequired();

                entity
                    .HasOne(m => m.CreatedMemberMailListGroup)
                    .WithMany(m => m.CreatedMemberMailListGroups)
                    .HasForeignKey(m => m.CreatedMemberId);

                entity
                    .HasOne(m => m.ModifiedMemberMailListGroup)
                    .WithMany(m => m.ModifiedMemberMailListGroups)
                    .HasForeignKey(m => m.ModifiedMemberId);
            });
        }
    }
}
