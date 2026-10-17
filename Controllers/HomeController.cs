using Microsoft.AspNetCore.Mvc;

namespace HHAManagementSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
