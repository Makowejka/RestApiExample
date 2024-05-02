using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Dto;
using RestApiExample.Web.Services;

namespace RestApiExample.Web.Controllers;

[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ProductDto>> GetAsync()
    {
        try
        {
            var productDto = await _productService.GetAsync();

            return Ok(productDto);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetAsync(int id)
    {
        try
        {
            var productDto = await _productService.GetAsync(id)!;

            if (productDto == null)
            {
                return NotFound();
            }

            return Ok(productDto);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
