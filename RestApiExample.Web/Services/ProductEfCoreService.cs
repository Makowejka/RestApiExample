using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Data;
using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Services;

public class ProductEfCoreService : IProductService
{
    private readonly DataContext _context;

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
}
