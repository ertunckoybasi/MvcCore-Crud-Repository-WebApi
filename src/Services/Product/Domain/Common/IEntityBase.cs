namespace ProductSrv.Domain.Common;
public interface IEntityBase
{
    public int Id { get; set; } 
    public DateTime? InsertDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
