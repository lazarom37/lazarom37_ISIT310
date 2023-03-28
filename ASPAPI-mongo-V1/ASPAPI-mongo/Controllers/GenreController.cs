using ASPAPI_mongo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPAPI_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        BacklogDbContext myCollections = new BacklogDbContext();
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return myCollections.Genres;
        }

        // POST api/Genre
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Genre newGenre = new Genre();
            newGenre.genreID = myCollections.Genres.Count();
            newGenre.genreDesc = value;
            myCollections.Add(newGenre);
            myCollections.SaveChanges();
        }
    }
}