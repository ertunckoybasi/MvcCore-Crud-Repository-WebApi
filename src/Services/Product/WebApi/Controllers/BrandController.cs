using System.Net;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductSrv.Application.Features.ProductFeature.Dtos;
using ProductSrv.Application.Features.ProductFeature.Queries.GetProductList;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class BrandController : Controller
{
    private readonly IBrandRepository _ProductService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public BrandController(IBrandRepository ProductRepository, IMediator mediator, IMapper mapper)
    {
        _ProductService = ProductRepository;
        _mapper = mapper;
        _mediator = mediator;
    }


    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IEnumerable<BrandDTO>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult<IEnumerable<ProductCreateDTO>>> GetBrands()
    {
        var query = new GetAllBrandsQuery();
        var ProductResponse = await _mediator.Send(query);
        if (!ProductResponse.Any()) return NoContent();
        return Ok(ProductResponse);
    }
}
