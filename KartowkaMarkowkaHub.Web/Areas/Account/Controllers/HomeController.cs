using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("[area]/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
