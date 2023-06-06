using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (VideogameContext context = new VideogameContext())
            {
                VideogameModel? videogameToEdit = context.Videogames.Where(videogame => videogame.Id == id).FirstOrDefault(); 
                if (videogameToEdit == null)
                {
                    return NotFound("Il videogame che cerchi non esiste!");
                } else
                {
                    return View("Update", videogameToEdit);
                }
            } 

        }

        [HttpPost]
        public IActionResult Update(int id, VideogameModel videogameUpdated)
        {
            if(!ModelState.IsValid)
            {
                return View("Update", videogameUpdated);
            } else
            {
                using (VideogameContext db = new VideogameContext())
                {
                    VideogameModel? videogameToUpdate = db.Videogames.Where(videogame => videogame.Id == id).FirstOrDefault();
                    if(videogameToUpdate == null)
                    {
                        return NotFound();
                    } else
                    {
                        videogameToUpdate.Name = videogameUpdated.Name;
                        videogameToUpdate.ImgUrl = videogameUpdated.ImgUrl;
                        videogameToUpdate.Price = videogameUpdated.Price;
                        videogameToUpdate.Description = videogameUpdated.Description;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
        }
    }

}
