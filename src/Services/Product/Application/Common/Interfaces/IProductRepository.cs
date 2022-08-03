using ProductSrv.Application.Features.ProductFeature.Dtos;
using ProductSrv.Domain.Entities;


namespace ProductSrv.Application.Common.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
    {
    Task<List<ProductListDTO>> GetProductWithBrand();
    }
