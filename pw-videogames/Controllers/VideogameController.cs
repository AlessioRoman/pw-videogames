using Microsoft.AspNetCore.Mvc;

namespace pw_videogames.Controllers
{
    public class VideogameController : Controller
    {
        public IActionResult Index()
        {
            using (VideogameContext db = new VideogameContext())
            {
                List<VideogameModel> videogame = db.Videogame.ToList();

                return View(videogame);
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
                    db.Books.Add(newVideogame);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }

}


