using RestApiExample.Web.Dto;
using RestApiExample.Web.Entity;

namespace RestApiExample.Web.Contract;

public interface IProductService
{
    Task<List<ProductDto>> GetAsync();

    Task<ProductDto?> GetAsync(int id);

    Task<ProductDto?> AddAsync(ProductDto productDto);

    Task<ProductDto?> UpdateAsync(int id, ProductDto productDto);

    Task<bool> DeleteAsync(int id);
}
