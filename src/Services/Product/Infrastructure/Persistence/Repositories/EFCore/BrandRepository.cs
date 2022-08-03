using Application.Common.Interfaces;
using Persistence.Data;
using Persistence.Repositories.EFCore;
using ProductSrv.Domain.Entities;

namespace Infrastructure.Persistence.Repositories.EFCore;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext context) : base(context)
    {

    }
}
