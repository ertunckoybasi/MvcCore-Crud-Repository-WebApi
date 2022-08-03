using ProductSrv.Domain.Entities;

namespace ProductSrv.Application.Features.ProductFeature.Dtos;

public class ProductDeleteDTO
{
    public int Id { get; set; }
}
public class ProductCreateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public int BrandId { get; set; }
    public Brand ProductBrand { get; set; }
}

public class ProductListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public Brand ProductBrand { get; set; }
}

public class BrandDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}

