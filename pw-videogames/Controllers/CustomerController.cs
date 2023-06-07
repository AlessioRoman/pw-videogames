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

        public IActionResult Details(int id)
        {
            using(VideogameContext db = new VideogameContext())
            {
                VideogameModel? videogameDetails = db.Videogames.Where(videogame => videogame.Id == id).FirstOrDefault();
                if(videogameDetails != null)
                {
                    return View("Details", videogameDetails);
                } else
                {
                    return NotFound($"Il videogioco con id {id} non è stato trovato!");
                }
            }
        }
    }
}
