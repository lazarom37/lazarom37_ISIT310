using ASPAPI_mongo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;





namespace ASPAPI_mongo.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {

        Dog[] dogsArray = new Dog[3];

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Dog> Get()
        {
            dogsArray[0] = new Dog("Border Collie", "Black", 4);
            dogsArray[1] = new Dog("Boxer", "Brown", 6);
            dogsArray[2] = new Dog("Golden", "Copper", 7);
            return dogsArray;
        }



        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
