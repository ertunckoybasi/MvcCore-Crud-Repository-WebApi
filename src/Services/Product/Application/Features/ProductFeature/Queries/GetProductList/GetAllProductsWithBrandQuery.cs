using ProductSrv.Application.Common.Interfaces;
using ProductSrv.Application.Features.ProductFeature.Dtos;
using AutoMapper;
using MediatR;

namespace ProductSrv.Application.Features.ProductFeature.Queries.GetProductList;

public class GetAllProductsWithBrandQuery : IRequest<List<ProductListDTO>>
{
    public class GetAllProductsWithBrandQueryHandler : IRequestHandler<GetAllProductsWithBrandQuery, List<ProductListDTO>>
    {
        private readonly IProductRepository ProductRepository;
        private readonly IMapper _mapper;
        public GetAllProductsWithBrandQueryHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            this.ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductListDTO>> Handle(GetAllProductsWithBrandQuery request, CancellationToken cancellationToken)
        {
            var Products = await ProductRepository.GetProductWithBrand();
            //var listVM = _mapper.Map<List<ProductListDTO>>(Products);
            return Products;
        }

    }
}
