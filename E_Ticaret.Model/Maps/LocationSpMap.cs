using E_Ticaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.Model.Maps
{
    public class LocationSpMap : IEntityTypeConfiguration<LocationSp>
    {
        public void Configure(EntityTypeBuilder<LocationSp> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
