using Microsoft.AspNetCore.Mvc;

namespace RestApiExample.Web.Controllers;

public class ProducttController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}