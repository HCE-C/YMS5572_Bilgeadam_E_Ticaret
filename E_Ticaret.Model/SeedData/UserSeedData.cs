using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Ticaret.Model.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData(
                new Member
                {
                    Id = 1,
                    Firstname = "Hüseyin",
                    Surname = "Ercan",
                    Email = "can@hotmail.com",
                    Password = "123456",
                    Title = "Admin",
                    Status = Core.Entity.Enums.Status.Active,
                    MemberStatus = MemberStatus.Active,
                    DeviceType = "Desktop"
                });
        }
    }
}
