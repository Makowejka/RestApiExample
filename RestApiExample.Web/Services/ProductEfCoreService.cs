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

    public ProductEfCoreService(DataContext context) => _context = context;

    public Task<List<ProductDto>> GetAsync()
    {
        return _context
            .Products
            .Select(x => new ProductDto(x.Id, x.Name, x.Brand, x.Size, x.Price))
            .ToListAsync();
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(d => d.Id.Equals(id));

        if (product == null)
        {
            return null;
        }

        return new ProductDto(product.Id, product.Name, product.Brand, product.Size, product.Price);
    }

    public async Task<int> AddAsync(ProductDto addProductDto)
    {
        var product = new Product
        {
            Name = addProductDto.Name,
            Brand = addProductDto.Brand,
            Size = addProductDto.Size,
            Price = addProductDto.Price
        };

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return product.Id;
    }

    public async Task UpdateAsync(int id, ProductDto updateProductDto)
    {
        var existingProduct = await _context.Products.FindAsync(id);

        if (existingProduct == null)
        {
            throw new NotFoundException($"Product with ID {id} not found!");
        }

        existingProduct.Brand = updateProductDto.Brand;
        existingProduct.Name = updateProductDto.Name;
        existingProduct.Size = updateProductDto.Size;
        existingProduct.Price = updateProductDto.Size;

        _context.Products.Update(existingProduct);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deletedProduct = await _context.Products.FindAsync(id);

        if (deletedProduct != null)
        {
            _context.Products.Remove(deletedProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
