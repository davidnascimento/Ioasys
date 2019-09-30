using Microsoft.EntityFrameworkCore;
using Ioasys.Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ioasys.Infra.Data.Mappings
{
    public class EnterpriseMapping : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Ent_Enterprise_Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasColumnName("Ent_Email")
                .HasMaxLength(200);

            builder.Property(x => x.Facebook)
                .HasColumnName("Ent_Facebook")
                .HasMaxLength(200);

            builder.Property(x => x.Twitter)
                .HasColumnName("Ent_Twitter")
                .HasMaxLength(200);

            builder.Property(x => x.Linkedin)
                .HasColumnName("Ent_Linkedin")
                .HasMaxLength(200);

            builder.Property(x => x.Phone)
                .HasColumnName("Ent_Phone")
                .HasMaxLength(200);

            builder.Property(x => x.Own)
                .HasColumnName("Ent_Own")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Ent_Name")
                .HasMaxLength(200);

            builder.Property(x => x.Photo)
                .HasColumnName("Ent_Photo")
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasColumnName("Ent_Description");

            builder.Property(x => x.City)
                .HasColumnName("Ent_City")
                .HasMaxLength(200);

            builder.Property(x => x.Country)
                .HasColumnName("Ent_Country")
                .HasMaxLength(200);

            builder.Property(x => x.Value)
                .HasColumnName("Ent_Value")
                .IsRequired();

            builder.Property(x => x.SharePrice)
                .HasColumnName("Ent_SharePrice")
                .IsRequired();

            builder.Property(x => x.EnterpriseTypeId)
                .HasColumnName("Ett_EnterpriseType_Id")
                .IsRequired();

            builder.HasOne(x => x.EnterpriseType)
                .WithMany(o => o.Enterprises)
                .HasForeignKey(x => x.EnterpriseTypeId)
                .IsRequired();

            builder.ToTable("Ent_Enterprise");
        }
    }
}
