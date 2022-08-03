using ProductSrv.Domain.Common;

namespace ProductSrv.Domain.Entities;
public class Brand:IEntityBase
{
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;
    public DateTime? InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
