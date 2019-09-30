using Ioasys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Usr_User_Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasColumnName("Usr_Email")
                .HasMaxLength(150);

            builder.Property(x => x.Password)
                .HasColumnName("Usr_Password")
                .HasMaxLength(150);

            builder.Property(x => x.EnterpriseId)
                .HasColumnName("Ent_Enterprise_Id");

            builder.HasOne(x => x.Enterprise)
                .WithMany(o => o.Users)
                .HasForeignKey(x => x.EnterpriseId);

            builder.Property(x => x.InvestorId)
                .HasColumnName("Inv_Investor_Id");

            builder.HasOne(x => x.Investor)
                .WithMany(o => o.Users)
                .HasForeignKey(x => x.InvestorId);

            builder.ToTable("Usr_User");
        }
    }
}
