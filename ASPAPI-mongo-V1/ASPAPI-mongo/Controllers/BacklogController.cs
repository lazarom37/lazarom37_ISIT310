using ASPAPI_mongo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPAPI_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        BacklogDbContext myCollections = new BacklogDbContext();


        [HttpGet]
        public IEnumerable<BacklogDetail> Get()
        {
            List<BacklogDetail> myList = new List<BacklogDetail>();

            var backlogQuery = from eachBacklog in myCollections.Backlogs
                               select new
                               {
                                eachBacklog.Title,
                                eachBacklog.Publisher.Country,
                                eachBacklog.Publisher.NamePub,
                                eachBacklog.Platform,
                                eachBacklog.Genre.genreDesc,
                                eachBacklog.Finished
                            };

            foreach (var entry in backlogQuery)
            {
                BacklogDetail newBacklogDetail = new BacklogDetail();
                newBacklogDetail.title = entry.Title;
                newBacklogDetail.country = entry.Country;
                newBacklogDetail.publisher = entry.NamePub;
                newBacklogDetail.platform = entry.Platform;
                newBacklogDetail.genre = entry.genreDesc;
                newBacklogDetail.Finished = entry.Finished;
                myList.Add(newBacklogDetail);
            }
            return myList;

        }

        // POST api/Genre
        [HttpPost]
        public void Post(BacklogSubset newBacklogSubset)
        {
            Backlog newBacklog = new Backlog();
            newBacklog.backlogID = myCollections.Backlogs.Count();
            newBacklog.Title = newBacklogSubset.title;
            newBacklog.Platform = newBacklogSubset.platform;
            newBacklog.Finished = newBacklogSubset.finished;
            newBacklog.publisherID = newBacklogSubset.PublisherID;
            newBacklog.genreID = newBacklogSubset.GenreID;

            myCollections.Add(newBacklog);
            myCollections.SaveChanges();
        }
    }

    public class BacklogDetail
    {
        public int backlogID { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string publisher { get; set; }
        public string platform { get; set; }
        public string genre { get; set; }
        public bool Finished { get; set; }

    }

    public class BacklogSubset
    {
        public string title { get; set; }
        public int PublisherID { get; set; }
        public int GenreID { get; set; }
        public string platform { get; set; }
        public bool finished { get; set; }
        public int backlogID { get; set; }
    }
}