using RestApiExample.Web.Contract;
using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Services;

public class OrderDapperService : IOrderService
{
    public Task<List<OrderDto>> GetAsyns()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto> GetAsyns(int id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto> AddAsync(OrderDto orderDto)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> UpdateAsync(int id, OrderDto orderDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
