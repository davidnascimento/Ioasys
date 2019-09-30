using Ioasys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Infra.Data.Mappings
{
    public class InvestorMapping : IEntityTypeConfiguration<Investor>
    {
        public void Configure(EntityTypeBuilder<Investor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Inv_Investor_Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Inv_Name")
                .HasMaxLength(200);

            builder.Property(x => x.Email)
                .HasColumnName("Inv_Email")
                .HasMaxLength(200);

            builder.Property(x => x.City)
                .HasColumnName("Ent_City")
                .HasMaxLength(200);

            builder.Property(x => x.Country)
                .HasColumnName("Ent_Country")
                .HasMaxLength(200);

            builder.Property(x => x.Balance)
                .HasColumnName("Inv_Balance")
                .IsRequired();

            builder.Property(x => x.Photo)
                .HasColumnName("Inv_Photo")
                .HasMaxLength(200);

            builder.Property(x => x.PortfolioValue)
                .HasColumnName("Inv_PortfolioValue")
                .HasMaxLength(200);

            builder.Property(x => x.FirstAccess)
                .HasColumnName("Inv_FirstAccess")
                .IsRequired();

            builder.Property(x => x.SuperAngel)
                .HasColumnName("Inv_SuperAngel")
                .IsRequired();

            builder.ToTable("Inv_Investor");
        }
    }
}