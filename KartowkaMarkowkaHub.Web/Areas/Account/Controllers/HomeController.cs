using Microsoft.AspNetCore.Mvc;

namespace KartowkaMarkowkaHub.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
