using ProductSrv.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductSrv.Infrastructure.Persistence.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
           .UseIdentityColumn();

        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.PictureUri)
           .HasMaxLength(300)
           .IsRequired();

        builder.Property(t => t.Price)
            .HasPrecision(18, 2)
           .IsRequired();

        builder.Property(t => t.InsertDate)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

        builder.Property(t => t.UpdateDate)
        .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnUpdate();

    }
}