using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.SeedData
{
    public class LocationSeedData : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location()
                {
                    Id = 2,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "Ankara",
                    CountryId = 1,
                    RegionId = 1
                },
                new Location()
                {
                    Id = 5,
                    Status = Core.Entity.Enums.Status.Active,
                    CreatedMemberId = 1,
                    Name = "İstanbul",
                    CountryId = 1,
                    RegionId = 3
                });
        }
    }
}
