using RestApiExample.Web.Contract;
using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Services;

public class ProductDapperService : IProductService
{
    public Task<List<ProductDto>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, ProductDto updateProductDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
