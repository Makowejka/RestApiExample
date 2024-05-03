using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Contract;

public interface IOrderService
{
    Task<List<OrderDto>> GetAsyns();

    Task<OrderDto> GetAsyns(int id);

    Task<OrderDto> AddAsync(OrderDto orderDto);

    Task<OrderDto?> UpdateAsync(int id, OrderDto orderDto);

    Task<bool> DeleteAsync(int id);
}
