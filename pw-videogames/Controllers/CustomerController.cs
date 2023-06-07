using Microsoft.AspNetCore.Mvc;
using pw_videogames.Database;
using pw_videogames.Models;

namespace pw_videogames.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            using (VideogameContext db = new VideogameContext())
            {
                List<VideogameModel> videogame = db.Videogames.ToList();

                return View(videogame);
            }
        }
    }
}
