using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Contract;

public interface IProductService
{
    Task<List<ProductDto>> GetAsync();

    Task<ProductDto?> GetAsync(int id);
}
