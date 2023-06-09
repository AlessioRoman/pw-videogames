using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pw_videogames.Database;
using pw_videogames.Models;

namespace pw_videogames.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideogameApi : ControllerBase
    {
        [HttpGet]
        
        public IActionResult GetVideogameList()
        {
            using (VideogameContext context = new VideogameContext())
            {
                IQueryable<VideogameModel> videogames = context.Videogames;

                return Ok(videogames.ToList());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVideogame(int id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                VideogameModel? videogameId = db.Videogames.Where(videogame => videogame.Id == id).FirstOrDefault();
                if (videogameId == null)
                {
                    return NotFound("Il videogame richiesto non esiste!");
                }
                else
                {
                    return Ok(videogameId);
                }
            }
        }

        [HttpGet("{key}")]
        public IActionResult SearchByTitle(string key)
        {
            using (VideogameContext db = new VideogameContext())
            {
                VideogameModel videogameToSearch = db.Videogames.Where(videogame => videogame.Name.Contains(key)).FirstOrDefault();
                if (videogameToSearch == null)
                {
                    return NotFound("Il videogame richiesto non esiste!");
                }
                else
                {
                    return Ok(videogameToSearch);
                }
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult AddLike(int id)
        {
            using(VideogameContext db = new VideogameContext())
            {
                VideogameModel videogame = db.Videogames.Where(videogame => videogame.Id == id).FirstOrDefault();
                if (videogame == null)
                {
                    return NotFound();
                } else
                {
                    videogame.Like = videogame.Like + 1;
                    db.SaveChanges();

                    return Ok();
                }
            }
        }

    }
}
