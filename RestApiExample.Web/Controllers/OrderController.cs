using Microsoft.AspNetCore.Mvc;

namespace RestApiExample.Web.Controllers;

public class OrderController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}