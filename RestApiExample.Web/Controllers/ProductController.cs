using Microsoft.AspNetCore.Mvc;
using RestApiExample.Web.EfCore;
using RestApiExample.Web.Model;

namespace RestApiExample.Web.Controllers;

[ApiController]
public class ProductController : Controller
{
    private readonly DbHelper _db;

    public ProductController(EfDataContext efDataContext)
    {
        _db = new DbHelper(efDataContext);
    }

    // GET api/<ProductController>
    [HttpGet]
    [Route("api/[controller]/GetProducts")]
    public IActionResult Get()
    {
        ApiResponse.ResponseType type = ApiResponse.ResponseType.Success;

        try
        {
            IEnumerable<ProductModel> data = _db.GetProducts();

            if (!data.Any())
            {
                type = ApiResponse.ResponseType.NotFound;
            }

            return Ok(ResponseHandler.GetAppResponse(type, data));
        }
        catch (Exception ex)
        {
            return BadRequest(ResponseHandler.GetExceptionResponse(ex));
        }
    }

    // GET api/<ProductController>/5
    [HttpGet]
    [Route("api/[controller]/GetProductById/{id:int}")]
    public IActionResult Get(int id)
    {
        ApiResponse.ResponseType type = ApiResponse.ResponseType.Success;

        try
        {
            var data = _db.GetProductById(id);

            if (data == null)
            {
                type = ApiResponse.ResponseType.NotFound;
            }

            return Ok(ResponseHandler.GetAppResponse(type, data));
        }
        catch (Exception ex)
        {
            return BadRequest(ResponseHandler.GetExceptionResponse(ex));
        }
    }

    // POST api/api/<ProductController>
    [HttpPost]
    [Route("api/[controller]/SaveOrder")]
    public IActionResult Post([FromBody] OrderModel model)
    {
        try
        {
            ApiResponse.ResponseType type = ApiResponse.ResponseType.Success;
            _db.SaveOrder(model);
            return Ok(ResponseHandler.GetAppResponse(type, model));
        }
        catch (Exception ex)
        {
            return BadRequest(ResponseHandler.GetExceptionResponse(ex));

        }
    }

    // PUT api/<ProductController>/5
    [HttpPut]
    [Route("api/[controller]/UpdateOrder/{id:int}")]
    public IActionResult Put(int id, [FromBody] OrderModel model)
    {
        try
        {
            ApiResponse.ResponseType type = ApiResponse.ResponseType.Success;

            _db.SaveOrder(model);

            return Ok(ResponseHandler.GetAppResponse(type, model));
        }
        catch (Exception ex)
        {
            return BadRequest(ResponseHandler.GetExceptionResponse(ex));
        }
    }

    // DELETE api/<ProductController>/5
    [HttpDelete]
    [Route("api/[controller]/DeleteeOrder/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            ApiResponse.ResponseType type = ApiResponse.ResponseType.Success;

            _db.DeleteOrder(id);

            return Ok(ResponseHandler.GetAppResponse(type, "Delete Sucessfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ResponseHandler.GetExceptionResponse(ex));
        }
    }
}
