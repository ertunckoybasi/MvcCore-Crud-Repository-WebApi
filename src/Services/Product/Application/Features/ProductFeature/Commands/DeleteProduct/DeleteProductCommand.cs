using ProductSrv.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Exceptions;
using ProductSrv.Domain.Entities;

namespace ProductSrv.Application.Features.ProductFeature.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public int ProductId { get; set; }
}

public class ProductDeleteHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public ProductDeleteHandler(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.ProductId < 1) throw new ValidationException($"Id should be greater than zero.");
        
        var product = await _ProductRepository.GetAsync(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), request.ProductId);
        }
        var sProduct = await _ProductRepository.DeleteAsyn(product);
        return Unit.Value;
    }
}
