using ASPAPI_mongo.Models;
using ASPAPI_mongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPAPI_mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoBacklogsController : ControllerBase
    {
        private readonly MongoBacklogsServices _backlogsService;
        public MongoBacklogsController(MongoBacklogsServices backlogsService) =>
        _backlogsService = backlogsService;

        [HttpGet]
        public async Task<List<MongoBacklog>> Get() =>
            await _backlogsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<MongoBacklog>> Get(string id)
        {
            var Backlog = await _backlogsService.GetAsync(id);
            if (Backlog is null)
            {
                return NotFound();
            }
            return Backlog;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProtoBacklog newBacklog)
        {
            MongoBacklog tempMongoBacklog = new MongoBacklog();
            tempMongoBacklog.Title = newBacklog.title;
            tempMongoBacklog.Country = newBacklog.country;
            tempMongoBacklog.Publisher = newBacklog.publisher;
            tempMongoBacklog.Platform = newBacklog.platform;
            tempMongoBacklog.Genre = newBacklog.genre;
            tempMongoBacklog.Finished = newBacklog.finished;

            await _backlogsService.CreateAsync(tempMongoBacklog);
            return CreatedAtAction(nameof(Get), newBacklog);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, MongoBacklog updatedBacklog)
        {
            var Backlog = await _backlogsService.GetAsync(id);
            if (Backlog is null)
            {
                return NotFound();
            }
            updatedBacklog.backlogID = Backlog.backlogID;
            await _backlogsService.UpdateAsync(id, updatedBacklog);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var backlog = await _backlogsService.GetAsync(id);
            if (backlog is null)
            {
                return NotFound();
            }
            await _backlogsService.RemoveAsync(id);
            return NoContent();
        }
    }
    public class ProtoBacklog
    {
        //public int backlogID { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string publisher { get; set; }
        public string platform { get; set; }
        public string genre { get; set; }
        public bool finished { get; set; }
    }
}