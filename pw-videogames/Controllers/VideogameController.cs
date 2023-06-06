using Microsoft.AspNetCore.Mvc;

namespace pw_videogames.Controllers
{
    public class VideogameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
