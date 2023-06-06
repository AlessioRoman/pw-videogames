using Microsoft.AspNetCore.Mvc;
using pw_videogames.Database;
using pw_videogames.Models;

namespace pw_videogames.Controllers
{
    public class VideogameController : Controller
    {
        public IActionResult Index()
        {
            using (VideogameContext db = new VideogameContext())
            {
                List<VideogameModel> videogames = db.Videogames.ToList();

                return View(videogames);
            }
        }

        // ACTION CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VideogameModel newVideogame)
        {
            if (!ModelState.IsValid)
            {
                return View(newVideogame);
            }
            else
            {
                using (VideogameContext db = new VideogameContext())
                {
                    db.Videogames.Add(newVideogame);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }

}
