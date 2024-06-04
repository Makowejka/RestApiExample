using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Dto;

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

    [HttpPost]
    public async Task<ActionResult<ProductDto>?> AddAsync([FromBody]ProductDto addProductDto)
    {
        try
        {
            var result = await _productService.AddAsync(addProductDto);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task UpdateAsync(int id, [FromBody] ProductDto updateProductDto)
    {
        try
        {
            await _productService.UpdateAsync(id, updateProductDto);
        }
        catch (Exception ex)
        {
            StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            bool deletedProduct = await _productService.DeleteAsync(id);

            if (deletedProduct)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
