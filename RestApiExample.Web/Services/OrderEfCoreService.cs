using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Data;
using RestApiExample.Web.Dto;
using RestApiExample.Web.Entity;

namespace RestApiExample.Web.Services;

public class OrderEfCoreService : IOrderService
{
    private readonly DataContext _context;

    public OrderEfCoreService(DataContext context)
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

    public async Task<OrderDto> AddAsync(OrderDto orderDto)
    {
        var orderEfCoreService = new OrderEfCoreService(_context);

        var result = await orderEfCoreService.AddAsync(orderDto);

        return result;
    }

    public async Task<OrderDto?> UpdateAsync(int id, OrderDto orderDto)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return null;
        }

        order.Address = orderDto.Address;
        order.Name = orderDto.Name;
        order.Phone = orderDto.Phone;

        return new OrderDto
        {
            Address = order.Address,
            Id = order.Id,
            Name = order.Name,
            ProductId = order.ProductId,
            Phone = order.Phone
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order != null)
        {
            _context.Orders.Remove(order);
        }

        await _context.SaveChangesAsync();

        return true;
    }
}
