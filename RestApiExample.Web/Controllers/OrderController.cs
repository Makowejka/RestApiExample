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
            var orderDto = await _orderService.GetAsyns();

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
            var orderDto = await _orderService.GetAsyns(id);

            return Ok(orderDto);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);

        }
    }
}
