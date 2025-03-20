using Microsoft.AspNetCore.Mvc;

namespace projeto1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
