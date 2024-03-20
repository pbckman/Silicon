using Microsoft.AspNetCore.Mvc;

namespace Silicon_1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
