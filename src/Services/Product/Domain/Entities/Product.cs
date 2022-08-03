
using ProductSrv.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSrv.Domain.Entities;

public class Product:IEntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public int BrandId { get; set; }
    public Brand ProductBrand { get; set; }
    public DateTime? InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public Product()
    {
        Name = String.Empty;
        Description = String.Empty;
        PictureUri = String.Empty;
        BrandId = 0;
        ProductBrand = new Brand();
    }
}

