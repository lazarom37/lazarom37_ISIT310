using ASPAPI_mongo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPAPI_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        BacklogDbContext myCollections = new BacklogDbContext();
        //[HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return myCollections.Publishers;
        }

        // POST api/Genre
        [HttpPost]
        public void Post(PublisherSubset newPublisherSubset)
        {
            Publisher newPublisher = new Publisher();
            newPublisher.publisherID = myCollections.Publishers.Count();
            newPublisher.NamePub = newPublisherSubset.namePub;
            newPublisher.Country = newPublisherSubset.country;
            myCollections.Add(newPublisher);
            myCollections.SaveChanges(); //Cannot insert the value NULL into column 'publisherID', table 'isit310db.dbo.Publishers'; column does not allow nulls. INSERT fails
        }

    }

    public class PublisherSubset
    {
        public string namePub { get; set; }
        public string country { get; set; }
    }
}
