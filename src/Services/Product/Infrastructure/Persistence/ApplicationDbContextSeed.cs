using ProductSrv.Domain.Entities;
using Persistence.Data;
using Bogus;

namespace ProductSrv.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        if (!context.Products.Any())
        {
            var brandFaker = new Faker<Brand>()
            .RuleFor(b => b.Id, b => b.IndexFaker)
            .RuleFor(b => b.Name, b => b.Company.CompanyName());

            var productFaker = new Faker<Product>("en")
               .RuleFor(i => i.Id, i => i.IndexFaker)
               .RuleFor(i => i.Name, i => i.Commerce.ProductName())
               .RuleFor(i => i.Description, i => i.Commerce.ProductDescription())
               .RuleFor(i => i.PictureUri, i => i.Image.PicsumUrl())
               .RuleFor(i => i.Price, i => i.Commerce.Price(5, 1000, 2).First())
               .RuleFor(i => i.ProductBrand, i =>
               {
                   return new Brand { Name = i.Company.CompanyName() };
               });

            var productlist = productFaker.Generate(10);

            foreach (var product in productlist)
            {
                Product pro = new Product();
                context.Products.Add(new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    PictureUri = product.PictureUri,
                    ProductBrand = new Brand { Name = product.ProductBrand.Name }
                    
                });
            }
        }
        await context.SaveChangesAsync();

    }
}
