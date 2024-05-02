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
}
