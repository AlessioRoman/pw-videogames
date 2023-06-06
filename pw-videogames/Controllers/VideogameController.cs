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

    // ACTION CREATE

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Pizza newVideogame)
    {
        if (!ModelState.IsValid)
        {
            return View("Create", newVideogame);
        }

        using (VideogameContext db = new VideogameContext())
        {
            db.Pizza.Add(newVideogame);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    // ACTION UPDATE

}


