using ProductSrv.Application.Common.Interfaces;
using ProductSrv.Application.Features.ProductFeature.Dtos;
using AutoMapper;
using MediatR;

namespace ProductSrv.Application.Features.ProductFeature.Queries.GetProductList;

public class GetAllProductsQuery : IRequest<List<ProductListDTO>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDTO>>
    {
        private readonly IProductRepository ProductRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            this.ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductListDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var Products = await ProductRepository.GetAllAsyn();
            var listVM = _mapper.Map<List<ProductListDTO>>(Products);
            return listVM;
        }

    }
}
