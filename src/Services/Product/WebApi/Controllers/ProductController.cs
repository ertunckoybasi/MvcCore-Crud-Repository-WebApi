using System.Net;
using ProductSrv.Application.Common.Interfaces;
using ProductSrv.Application.Features.ProductFeature.Dtos;
using ProductSrv.Application.Features.ProductFeature.Queries.GetProductList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductSrv.Application.Features.ProductFeature.Commands.CreateProduct;
using ProductSrv.Domain.Entities;
using ProductSrv.Application.Features.ProductFeature.Commands.DeleteProduct;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly IProductRepository _ProductService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public ProductController(IProductRepository ProductRepository, IMediator mediator, IMapper mapper)
    {
        _ProductService = ProductRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(IEnumerable<ProductCreateDTO>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult<IEnumerable<ProductCreateDTO>>> GetProducts()
    {
        var query = new GetAllProductsWithBrandQuery();
        var ProductResponse = await _mediator.Send(query);
        if (!ProductResponse.Any()) return NotFound();
        return Ok(ProductResponse);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var product=await _mediator.Send(command);
        return product != null ? Created("Home", product) : BadRequest();
    }

    [HttpDelete]
    [Route("Delete/{Id}")]
    public async Task<ActionResult<Unit>> Delete(int Id)
    {
        return await _mediator.Send(new DeleteProductCommand { ProductId = Id });
    }

}
