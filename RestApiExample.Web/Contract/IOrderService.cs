using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Contract;

public interface IOrderService
{
    Task<List<OrderDto>> GetAsync();

    Task<OrderDto> GetAsync(int id);

    Task<long> AddAsync(AddOrderDto dto);

    Task UpdateAsync(int id, OrderDto updateOrderDto);

    Task<bool> DeleteAsync(int id);
}
