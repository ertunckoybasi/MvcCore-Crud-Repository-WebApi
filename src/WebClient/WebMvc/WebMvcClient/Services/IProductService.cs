using Microsoft.AspNetCore.Mvc;
using WebMvcClient.Models;

namespace WebMvcClient.Services;

public interface IProductService
{
    Task<List<Brand>> GetBrandList();
    Task<List<Product>> GetProductList();
    Task<Product> GetProductById(int id);
    Task<ActionResult<Product>> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<ActionResult<Product>> DeleteByIdAsync(int id);
}
