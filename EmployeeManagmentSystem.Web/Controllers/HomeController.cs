namespace EmployeeManagementSystem.Web.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    public IActionResult Index() => View(nameof(Index));
}
