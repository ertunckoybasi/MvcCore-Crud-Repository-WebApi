using ProductSrv.Application.Common.Interfaces;
using ProductSrv.Application.Features.ProductFeature.Dtos;
using AutoMapper;
using ProductSrv.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories.EFCore;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    protected new ApplicationDbContext _context;
    protected IMapper _mapper;
    public ProductRepository(ApplicationDbContext context,IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ProductListDTO>> GetProductWithBrand()
    {
        var proList = await _context.Products.Include(t=>t.ProductBrand).ToListAsync();
        var proVM = _mapper.Map<List<ProductListDTO>>(proList);
        return proVM;
    }

    public Task<decimal> GetSalaryAsync(int Id)
    {
        decimal mdSalary = 5000;
        return Task.FromResult(mdSalary);
    }
}

