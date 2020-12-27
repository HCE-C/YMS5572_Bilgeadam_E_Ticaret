using E_Ticaret.Core.Map;
using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.SeedData
{
    public class CountrySeedData : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country()
                {
                    Id = 1,
                    Status = Core.Entity.Enums.Status.Active,
                    Name = "Türkiye",
                    CreatedMemberId = 1
                },
                new Country()
                {
                    Id = 2,
                    Status = Core.Entity.Enums.Status.Active,
                    Name = "Almanya",
                    CreatedMemberId = 1
                });
        }
    }
}
