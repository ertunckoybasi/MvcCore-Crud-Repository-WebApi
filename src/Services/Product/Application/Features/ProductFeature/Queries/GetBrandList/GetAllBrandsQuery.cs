
using AutoMapper;
using MediatR;
using Application.Common.Interfaces;
using ProductSrv.Application.Features.ProductFeature.Dtos;

namespace ProductSrv.Application.Features.ProductFeature.Queries.GetProductList;

public class GetAllBrandsQuery : IRequest<List<BrandDTO>>
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandDTO>>
    {
        private readonly IBrandRepository BrandRepository;
        private readonly IMapper _mapper;
        public GetAllBrandsQueryHandler(IBrandRepository BrandRepository, IMapper mapper)
        {
            this.BrandRepository = BrandRepository;
            _mapper = mapper;
        }
        public async Task<List<BrandDTO>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var Brands = await BrandRepository.GetAllAsyn();
            var listVM = _mapper.Map<List<BrandDTO>>(Brands);
            return listVM;
        }

    }
}
