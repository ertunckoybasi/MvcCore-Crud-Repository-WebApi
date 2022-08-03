using ProductSrv.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductSrv.Infrastructure.Persistence.Configuration;
public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
           .UseIdentityColumn();

        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.InsertDate)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.UpdateDate)
        .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnUpdate();
    }
}
