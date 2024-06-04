using System.Net;
using Microsoft.AspNetCore.Mvc;
using RestApiExample.Web.Contract;
using RestApiExample.Web.Dto;

namespace RestApiExample.Web.Controllers;

[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<OrderDto>> GetAsync()
    {
        try
        {
            var orderDto = await _orderService.GetAsync();

            return Ok(orderDto);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("{id:int}")]

    public async Task<ActionResult<OrderDto>> GetAsync(int id)
    {
        try
        {
            var orderDto = await _orderService.GetAsync(id);

            return Ok(orderDto);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

        }
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> AddAsync([FromBody] AddOrderDto addOrderDto)
    {
        try
        {
            var result = await _orderService.AddAsync(addOrderDto);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    [Route("{id:int}")]

    public async Task UpdateAsync(int id, OrderDto updateOrderDto)
    {
        try
        {
            await _orderService.UpdateAsync(id, updateOrderDto);
        }
        catch (Exception ex)
        {
            StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            bool deleteOrder = await _orderService.DeleteAsync(id);

            if (deleteOrder)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
