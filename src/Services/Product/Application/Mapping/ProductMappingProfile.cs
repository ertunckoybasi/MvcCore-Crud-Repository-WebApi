using ProductSrv.Application.Features.ProductFeature.Dtos;
using AutoMapper;
using ProductSrv.Domain.Entities;
using ProductSrv.Application.Features.ProductFeature.Commands.CreateProduct;

namespace ProductSrv.Application.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductCreateDTO>();
        CreateMap<ProductCreateDTO, Product>();
        CreateMap<ProductListDTO, Product>();
        CreateMap<Product, ProductListDTO>();
        CreateMap<Brand,BrandDTO>();
        CreateMap<BrandDTO, Brand>();
        CreateMap<Product,CreateProductCommand > ();
    }
}
