using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMvcClient.Models;
using WebMvcClient.Services;

namespace WebMvcClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productSvc;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productSvc = productService;
    }

    public async Task<IActionResult> Index()
    {
        var proList = await _productSvc.GetProductList();
        var brandList = await _productSvc.GetBrandList();
        ViewBag.ProductList = proList;
        ViewBag.BrandList = brandList;
        return View(new Product());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(Product product)
    {

        if (ModelState.IsValid)
        {
            var response = await _productSvc.CreateAsync(product);
            if (response == null) return RedirectToAction("Error");
        }
        else { return RedirectToAction("Error"); }

        return RedirectToAction("Index");
    }

    
  
    public IActionResult DeleteProduct(int Id)
    {
        try
        {
            var response= _productSvc.DeleteByIdAsync(Id);
            if (response == null)
            {
                _logger.LogError($"Owner with id: {Id}, hasn't been found in db.");
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}