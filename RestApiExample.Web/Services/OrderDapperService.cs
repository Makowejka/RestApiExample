using RestApiExample.Web.Contract;
using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Services;

public class OrderDapperService : IOrderService
{
    public Task<List<OrderDto>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<long> AddAsync(AddOrderDto dto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, OrderDto updateOrderDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
