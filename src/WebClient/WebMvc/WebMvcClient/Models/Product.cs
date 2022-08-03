using System.ComponentModel.DataAnnotations;

namespace WebMvcClient.Models;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public int BrandId { get; set; }
    public Brand ProductBrand { get; set; }
}

public class Brand
{
    public int Id { get; set; }

    public string Name { get; set; }
}
