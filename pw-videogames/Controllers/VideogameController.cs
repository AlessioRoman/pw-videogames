using Microsoft.AspNetCore.Mvc;

namespace pw_videogames.Controllers
{
    public class VideogameController : Controller
    {
        public IActionResult Index()
        {
            using (VideogameContext db = new VideogameContext())
            {
                List<Videogame> vgList = db.Videogame.ToList();
                return View(vgList);
            }
        }
    }
}
