using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Contract;

public interface IOrderService
{
    Task<List<OrderDto>> GetAsyns();

    Task<OrderDto> GetAsyns(int id );
}
