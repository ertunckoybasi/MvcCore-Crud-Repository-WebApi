using ProductSrv.Application.Common.Interfaces;
using ProductSrv.Application.Features.ProductFeature.Dtos;
using AutoMapper;
using ProductSrv.Domain.Entities;
using MediatR;

namespace ProductSrv.Application.Features.ProductFeature.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductCreateDTO>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUri { get; set; }
    public int BrandId { get; set; }
}
public class ProductCreateHandler : IRequestHandler<CreateProductCommand, ProductCreateDTO>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public ProductCreateHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }

    public async Task<ProductCreateDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ProductCreateDTO ProductResponse = null;

        try
        {
            Product productModel = new Product
            {
                BrandId = request.BrandId,
                ProductBrand = null,
                Description = request.Description,
                Price = request.Price,
                PictureUri = request.PictureUri,
                Name = request.Name
            };

            var sProduct = await _ProductRepository.AddAsyn(productModel);
            ProductResponse = _mapper.Map<ProductCreateDTO>(sProduct);
        }

        catch
        {

        }

        return ProductResponse;
    }


}
