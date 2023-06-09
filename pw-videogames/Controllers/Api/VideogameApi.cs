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

        [HttpGet]
        public IActionResult SearchByTitle(string Key)
        {
            using (VideogameContext db = new VideogameContext())
            {
                VideogameModel videogameToSearch = db.Videogames.Where(videogame => videogame.Name.Contains(Key)).FirstOrDefault();
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

    }
}
