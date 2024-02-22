using Microsoft.AspNetCore.Mvc;

namespace CTS.App.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Ok("I'm a core app");
        }
    }
}
