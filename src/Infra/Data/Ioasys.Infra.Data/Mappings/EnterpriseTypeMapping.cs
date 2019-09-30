using Ioasys.Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Infra.Data.Mappings
{
    public class EnterpriseTypeMapping : IEntityTypeConfiguration<EnterpriseType>
    {
        public void Configure(EntityTypeBuilder<EnterpriseType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Ett_EnterpriseType_Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Ett_Name")
                .HasMaxLength(200);

            builder.ToTable("Ett_EnterpriseType");
        }
    }
}
