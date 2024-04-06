using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silicon_1.Controllers;

[Authorize]
public class AccountController : Controller
{
    public IActionResult Details()
    {
        return View();
    }
}
