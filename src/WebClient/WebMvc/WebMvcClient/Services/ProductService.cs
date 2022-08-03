using System.Net.Http.Headers;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMvcClient.Models;

namespace WebMvcClient.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;
    readonly string apiCreateProductAddress = "http://localhost:5000/Product/Create";
    readonly string apiGetAllProductsAddress = "http://localhost:5000/Product/GetAllProducts";
    readonly string apiGetAllBrandsAddress = "http://localhost:5000/Brand/GetAllBrands";
    readonly string apiDeleteProductAddress = "http://localhost:5000/Product/Delete/";
    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> CreateAsync(Product product)
    {
        try
        {
            var dataAsString = JsonConvert.SerializeObject(product);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var _httpClient = _httpClientFactory.CreateClient();

            var response = await _httpClient.PostAsync(apiCreateProductAddress, content);

            if (response.IsSuccessStatusCode)
            { var responseData = await response.Content.ReadAsStringAsync(); }
            else return null;
        }
        catch
        {
            return null;
        }

        return product;
    }
    public Task<Product> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProductList()
    {
        try
        {
            var _httpClient = _httpClientFactory.CreateClient();
            var response = await _httpClient.GetAsync(apiGetAllProductsAddress);
            var responseData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(responseData);
            return result;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return null;
    }

    public async Task<List<Brand>> GetBrandList()
    {
        try
        {
            var _httpClient = _httpClientFactory.CreateClient();
            var response = await _httpClient.GetAsync(apiGetAllBrandsAddress);
            var responseData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Brand>>(responseData);
            return result;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }

        return null;
    }

    public Task<Product> UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<ActionResult<Product>> DeleteByIdAsync(int id)
    {
        string apiUrl = string.Format($"{apiDeleteProductAddress}{id}");
        var _httpClient = _httpClientFactory.CreateClient();
        var response = await _httpClient.DeleteAsync(apiUrl);
        if (response.IsSuccessStatusCode) Console.Write("Success"); else Console.Write("Error");
        return new NoContentResult();
    }
}
