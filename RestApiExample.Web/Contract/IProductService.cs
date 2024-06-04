using RestApiExample.Web.Dto;
using RestApiExample.Web.Entity;

namespace RestApiExample.Web.Contract;

public interface IProductService
{
    Task<List<ProductDto>> GetAsync();

    Task<ProductDto?> GetAsync(int id);

    Task<int> AddAsync(ProductDto productDto);

    Task UpdateAsync(int id, ProductDto updateProductDto);

    Task<bool> DeleteAsync(int id);
}
