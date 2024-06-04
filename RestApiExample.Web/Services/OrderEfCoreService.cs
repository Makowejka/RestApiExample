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

    public Task<List<OrderDto>> GetAsync()
    {
        return _context
            .Orders
            .Select(x => new OrderDto(x.Id, x.ProductId, x.Name, x.Address, x.Phone))
            .ToListAsync();
    }

    public async Task<OrderDto> GetAsync(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(d => d.Id.Equals(id));

        if (order == null)
        {
            return null!;
        }

        return new OrderDto(order.Id, order.ProductId, order.Name, order.Address, order.Phone);
    }

    public async Task<long> AddAsync(AddOrderDto dto)
    {
        var order = new Order
        {
            ProductId = dto.ProductId,
            Name = dto.Name,
            Phone = dto.Phone,
            Address = dto.Address
        };

        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        return order.Id;
    }

    public async Task UpdateAsync(int id, UpdateOrderDto dto)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

        if (order == null)
        {
            throw new NotFoundException($"Order with ID {id} not found!");
        }

        order.Address = dto.Address;
        order.Name = dto.Name;
        order.Phone = dto.Phone;

        _context.Orders.Update(order);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
