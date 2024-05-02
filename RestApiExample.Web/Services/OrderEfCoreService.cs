using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Data;
using RestApiExample.Web.Dto;
using RestApiExample.Web.Entity;

namespace RestApiExample.Web.Services;

public class OrderEfCoreService : IOrderService
{
    private readonly DataContext _context;

    OrderEfCoreService(DataContext context)
    {
        _context = context;
    }

    public Task<List<OrderDto>> GetAsyns()
    {
        return _context
            .Orders
            .Select(x => new OrderDto
            {
                Address = x.Address,
                Id = x.Id,
                Name = x.Name,
                ProductId = x.ProductId,
                Phone = x.Phone
            })
            .ToListAsync();
    }

    public async Task<OrderDto> GetAsyns(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(d => d.Id.Equals(id));

        if (order == null)
        {
            return null!;
        }

        return new OrderDto
        {
            Id = order.Id,
            Address = order.Address,
            Name = order.Name,
            ProductId = order.ProductId,
            Phone = order.Phone
        };
    }
}
