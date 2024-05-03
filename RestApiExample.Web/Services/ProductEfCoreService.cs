using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Data;
using RestApiExample.Web.Dto;
using RestApiExample.Web.Entity;

namespace RestApiExample.Web.Services;

public class ProductEfCoreService : IProductService
{
    private readonly DataContext _context;
    private IProductService? _productServiceImplementation;

    public ProductEfCoreService(DataContext context) => _context = context;

    public Task<List<ProductDto>> GetAsync()
    {
        return _context
            .Products
            .Select(x => new ProductDto
                {
                    Brand = x.Brand,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Size = x.Size
                }
            ).ToListAsync();
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(d => d.Id.Equals(id));

        if (product == null)
        {
            return null;
        }

        return new ProductDto
        {
            Brand = product.Brand,
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Size = product.Size
        };
    }

    public async Task<ProductDto?> AddAsync(ProductDto productDto)
    {
        var productEfCoreService = new ProductEfCoreService(_context);

        var result = await productEfCoreService.AddAsync(productDto);

        return result;
    }

    public async Task<ProductDto?> UpdateAsync(int id, ProductDto productDto)
    {
        var existingProduct = await _context.Products.FindAsync(id);

        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Brand = productDto.Brand;
        existingProduct.Name = productDto.Name;
        existingProduct.Size = productDto.Size;
        existingProduct.Price = productDto.Size;

        return new ProductDto
        {
            Brand = existingProduct.Brand,
            Id = existingProduct.Id,
            Name = existingProduct.Name,
            Price = existingProduct.Price,
            Size = existingProduct.Size
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deletedProduct = await _context.Products.FindAsync(id);

        if (deletedProduct != null) _context.Products.Remove(deletedProduct);

        await _context.SaveChangesAsync();

        return true;
    }
}
