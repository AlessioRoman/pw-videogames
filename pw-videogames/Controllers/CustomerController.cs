using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
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

        public IActionResult Confirm()
        {
            return View();
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

        public IActionResult Buy(int id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                TransactionModel newTransaction = new();
                newTransaction.Videogame = db.Videogames.Where(videogame => videogame.Id == id).FirstOrDefault();
                if (newTransaction.Videogame != null)
                {
                    return View("Buy", newTransaction);
                }
                else
                {
                    return NotFound($"Il videogioco con id {id} non è stato trovato!");
                }
            }
        }

        [HttpPost]
        public IActionResult Buy(TransactionModel data) 
        {
            using (VideogameContext db = new VideogameContext())
            {
                TransactionModel newTransaction = new();
                newTransaction.Videogame = db.Videogames.Where(videogame => videogame.Name.Contains(data.Videogame.Name)).FirstOrDefault();
                newTransaction.Quantity = data.Quantity;
                newTransaction.Date = DateTime.Now;
                db.Add(newTransaction);
                db.SaveChanges();

                return RedirectToAction("Confirm");
            }
        }
    }
}
